using LiveSplit.Model;
using LiveSplit.TimeFormatters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.Server;
using System.IO.Pipes;
using System.Threading;
using System.Text;

namespace LiveSplit.UI.Components {
    public class IGTComponent : IComponent {

        protected InfoTimeComponent InternalComponent {
            get; set;
        }

        public IGTSettings Settings {
            get; set;
        }
        protected LiveSplitState CurrentState {
            get; set;
        }

        public string ComponentName => "IGT";

        public float HorizontalWidth => InternalComponent.HorizontalWidth;
        public float MinimumHeight => InternalComponent.MinimumHeight;
        public float VerticalHeight => InternalComponent.VerticalHeight;
        public float MinimumWidth => InternalComponent.MinimumWidth;

        public float PaddingTop => InternalComponent.PaddingTop;
        public float PaddingBottom => InternalComponent.PaddingBottom;
        public float PaddingLeft => InternalComponent.PaddingLeft;
        public float PaddingRight => InternalComponent.PaddingRight;

        public IDictionary<string, Action> ContextMenuControls => new Dictionary<string, Action> {};

        protected NamedPipeServerStream WaitingServerPipe {
            get; set;
        }

        public List<Connection> PipeConnections {
            get; set;
        }

        private Thread pipeThread;

        private NamedPipeServerStream pipeServer = new NamedPipeServerStream("LiveSplitIGT", PipeDirection.InOut);

        // Mark time, in ticks
        private long Mark = 0;

        // Mark IGT, in ticks
        private long MarkIGT = 0;

        public IGTComponent(LiveSplitState state) {
            Settings = new IGTSettings();
            InternalComponent = new InfoTimeComponent(Settings.DisplayName, TimeSpan.Zero, new GeneralTimeFormatter());

            state.OnStart += state_OnStart;
            state.OnSplit += state_OnSplitChange;
            state.OnSkipSplit += state_OnSplitChange;
            state.OnUndoSplit += state_OnSplitChange;
            state.OnReset += state_OnReset;
            CurrentState = state;

            PipeConnections = new List<Connection>();

            pipeThread = new Thread(() => {
                byte[] buf = new byte[65536];
                while(true) {
                    pipeServer.WaitForConnection();
                    long recvTime = state.CurrentAttemptDuration.Ticks;

                    int read = pipeServer.Read(buf, 0, 65535);

                    String message = Encoding.ASCII.GetString(buf, 0, read);
                    string[] args = message.Split(" ".ToCharArray(), 2);
                    string command = args[0];

                    switch(command) {
                        case "mark":
                            Mark = recvTime;
                            break;
                        case "markigt":
                            try {
                                MarkIGT = (long) (double.Parse(args[1]) * TimeSpan.TicksPerSecond);
                            } catch (FormatException ex) {
                                // do nothing
                            }
                            break;
                    }

                    pipeServer.Disconnect();
                }
            });
            pipeThread.Start();
        }

        public void Dispose() {
            CurrentState.OnStart -= state_OnStart;
            CurrentState.OnSplit -= state_OnSplitChange;
            CurrentState.OnSkipSplit -= state_OnSplitChange;
            CurrentState.OnUndoSplit -= state_OnSplitChange;
            CurrentState.OnReset -= state_OnReset;

            pipeThread.Abort();
            // dirty hack incoming!
            NamedPipeClientStream force_close = new NamedPipeClientStream(".", "LiveSplitIGT");
            force_close.Connect();
            force_close.Close();
        }

        void state_OnStart(object sender, EventArgs e) {
            Mark = 0;
            MarkIGT = (long) (Settings.InitialIGT * TimeSpan.TicksPerSecond);
        }

        void state_OnSplitChange(object sender, EventArgs e) {

        }

        void state_OnReset(object sender, TimerPhase e) {
            Mark = 0;
            MarkIGT = (long) (Settings.InitialIGT * TimeSpan.TicksPerSecond);
        }

        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion) {
            InternalComponent.NameLabel.HasShadow = InternalComponent.ValueLabel.HasShadow = state.LayoutSettings.DropShadows;

            InternalComponent.NameLabel.ForeColor = state.LayoutSettings.TextColor;
            InternalComponent.ValueLabel.ForeColor = state.LayoutSettings.TextColor;

            InternalComponent.DrawHorizontal(g, state, height, clipRegion);
        }

        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion) {
            InternalComponent.DisplayTwoRows = Settings.Display2Rows;

            InternalComponent.NameLabel.HasShadow
                = InternalComponent.ValueLabel.HasShadow
                = state.LayoutSettings.DropShadows;

            InternalComponent.NameLabel.ForeColor = state.LayoutSettings.TextColor;
            InternalComponent.ValueLabel.ForeColor = state.LayoutSettings.TextColor;

            InternalComponent.DrawVertical(g, state, width, clipRegion);
        }

        public XmlNode GetSettings(XmlDocument document) {
            return Settings.GetSettings(document);
        }

        public Control GetSettingsControl(LayoutMode mode) {
            Settings.Mode = mode;
            return Settings;
        }

        public void SetSettings(XmlNode settings) {
            Settings.SetSettings(settings);
        }

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode) {
            if(state.CurrentPhase == TimerPhase.Running || state.CurrentPhase == TimerPhase.Paused) {
                InternalComponent.TimeValue = new TimeSpan((long) ((state.CurrentAttemptDuration.Ticks - Mark) * (Settings.FPS / 60.0d)) + MarkIGT);
            } else if (state.CurrentPhase == TimerPhase.NotRunning) {
                InternalComponent.TimeValue = new TimeSpan(MarkIGT);
            }
            InternalComponent.NameLabel.Text = Settings.DisplayName;
            InternalComponent.Update(invalidator, state, width, height, mode);
        }

        public int GetSettingsHashCode() => Settings.GetSettingsHashCode();
    }
}
