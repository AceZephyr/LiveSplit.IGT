using LiveSplit.Model;
using System;

namespace LiveSplit.UI.Components {
    internal class IGTFactory : IComponentFactory {
        public string ComponentName => "IGT";
        public string Description => "IGT Component Description";

        public ComponentCategory Category => ComponentCategory.Timer;

        public IComponent Create(LiveSplitState state) => new IGTComponent(state);

        public string UpdateName => ComponentName;

        public string UpdateURL => "";

        public string XMLURL => UpdateURL + "";

        public Version Version => Version.Parse("0.0.1");
    }
}
