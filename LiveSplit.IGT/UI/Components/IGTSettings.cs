using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;

namespace LiveSplit.UI.Components {
    public partial class IGTSettings : UserControl {

        public bool Display2Rows {
            get; set;
        }

        public double FPS {
            get; set;
        }

        public string DisplayName {
            get; set;
        }

        public double InitialIGT {
            get; set;
        }

        public LayoutMode Mode {
            get; set;
        }

        public IGTSettings() {
            InitializeComponent();
        }

        private void UpdateFPS() {
            try {
                var tmp = double.Parse(inputFPS.Text);
                if(tmp > 0)
                    FPS = tmp;
            } catch(FormatException e) {
                // do nothing
            }
        }

        private void UpdateDisplayName() {
            DisplayName = inputDisplayName.Text;
        }

        private void UpdateInitialIGT() {
            try {
                InitialIGT = double.Parse(inputInitialIGT.Text);
            } catch(FormatException e) {
                // do nothing
            }
        }

        private void IGTSettings_Load(object sender, EventArgs e) {
            if(Mode == LayoutMode.Horizontal) {
                checkBoxDisplayTwoRows.Enabled = false;
                checkBoxDisplayTwoRows.DataBindings.Clear();
                checkBoxDisplayTwoRows.Checked = true;
            } else {
                checkBoxDisplayTwoRows.Enabled = true;
                checkBoxDisplayTwoRows.DataBindings.Clear();
                checkBoxDisplayTwoRows.DataBindings.Add("Checked", this, "Display2Rows", false, DataSourceUpdateMode.OnPropertyChanged);
            }
            inputFPS.Text = FPS.ToString();
            inputDisplayName.Text = DisplayName;
            inputInitialIGT.Text = InitialIGT.ToString();
        }

        private int CreateSettingsNode(XmlDocument document, XmlElement parent) {
            return SettingsHelper.CreateSetting(document, parent, "Version", "1.0") ^
                SettingsHelper.CreateSetting(document, parent, "FPS", FPS) ^
                SettingsHelper.CreateSetting(document, parent, "Display2Rows", Display2Rows) ^
                SettingsHelper.CreateSetting(document, parent, "DisplayName", DisplayName) ^
                SettingsHelper.CreateSetting(document, parent, "InitialIGT", InitialIGT);
        }

        public XmlNode GetSettings(XmlDocument document) {
            var parent = document.CreateElement("Settings");
            CreateSettingsNode(document, parent);
            return parent;
        }

        public int GetSettingsHashCode() {
            return CreateSettingsNode(null, null);
        }

        public void SetSettings(XmlNode node) {
            var element = (XmlElement) node;
            FPS = SettingsHelper.ParseDouble(element["FPS"], 60);
            Display2Rows = SettingsHelper.ParseBool(element["Display2Rows"], false);
            DisplayName = SettingsHelper.ParseString(element["DisplayName"], "In-Game Time");
            InitialIGT = SettingsHelper.ParseDouble(element["InitialIGT"], 0.0);
        }

        private void inputFPS_TextChanged(object sender, EventArgs e) {
            UpdateFPS();
        }

        private void inputDisplayName_TextChanged(object sender, EventArgs e) {
            UpdateDisplayName();
        }

        private void inputInitialIGT_TextChanged(object sender, EventArgs e) {
            UpdateInitialIGT();
        }
    }
}
