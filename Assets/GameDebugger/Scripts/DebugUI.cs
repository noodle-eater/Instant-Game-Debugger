using UnityEngine;

namespace InGameDebugger {
    internal class DebugUI {
        
        public GameObject Button { get; private set; }
        public GameObject Text { get; private set; }
        public GameObject Separator { get; private set; }
        public GameObject Dropdown { get; private set; }
        public GameObject Console { get; private set; }
        public GameObject ConsoleText { get; private set; }

        public void Init() {
            Button = Resources.Load<GameObject>("Debug Button");
            Text = Resources.Load<GameObject>("Debug Text");
            Separator = Resources.Load<GameObject>("Debug Separator");
            Dropdown = Resources.Load<GameObject>("Debug Dropdown");
            Console = Resources.Load<GameObject>("Debug Console");
            ConsoleText = Resources.Load<GameObject>("Console Text");
        }
    }
}