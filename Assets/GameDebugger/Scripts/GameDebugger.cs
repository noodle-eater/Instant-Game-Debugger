using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InGameDebugger {

    public class GameDebugger
    {

        private GameDebugBehaviour debuggerBehaviour;
        private int counter = 0;

        /// <summary>
        /// Initialize the Debugger Canvas and all required config.
        /// </summary>
        public void Init() {
            debuggerBehaviour = GameDebugBehaviour.Init();
        }

        /// <summary>
        /// Add a button for run a task when clicked.
        /// </summary>
        public void AddButton(string buttonName, System.Action OnClicked) {
            var go = debuggerBehaviour.InstantiateInCanvas(DebugType.Button);
            go.name = counter + " - " + buttonName;
            go.GetComponent<Button>().onClick.AddListener(() => OnClicked());
            go.GetComponentInChildren<Text>().text = buttonName;
        }

        ///<summary>
        /// Add an interactive text that will be updated each frame.
        ///</summary>
        public void AddText(System.Func<string> GetText) {
            var go = debuggerBehaviour.InstantiateInCanvas(DebugType.Text);
            var uiText = go.GetComponent<Text>();
            uiText.text = GetText?.Invoke();
            debuggerBehaviour.OnUpdate += () => uiText.text = GetText?.Invoke();
        }

        /// <summary>
        /// Add static text.
        ///</summary>
        public void AddText(string text) {
            var go = debuggerBehaviour.InstantiateInCanvas(DebugType.Text);
            var uiText = go.GetComponent<Text>();
            uiText.text = text;
        }

        /// <summary>
        /// Add black straight line to separate list of UI.
        /// </summary>
        public void AddSeparator() {
            debuggerBehaviour.InstantiateInCanvas(DebugType.Separator);
        }

        /// <summary>
        /// Add a dropdown choince into the debugger UI.
        /// </summary>
        public void AddDropDown(string[] options, System.Action<int> OnOptionSelected) {
            var go = debuggerBehaviour.InstantiateInCanvas(DebugType.Dropdown);
            var dropdown = go.GetComponent<Dropdown>();
            var data = new List<Dropdown.OptionData>();
            
            for(int i = 0; i < options.Length; i++) {
                data.Add(new Dropdown.OptionData(options[i]));
            }

            dropdown.options = data;
            dropdown.onValueChanged.AddListener((selectedIndex) => OnOptionSelected?.Invoke(selectedIndex));
        }

        /// <summary>
        /// Add a small console window to the game.
        /// </summary>
        public void AddConsole() {
            debuggerBehaviour.InstantiateInCanvas(DebugType.Console);
        }

        public void CopyLogToClipboard() {
            CopyText(debuggerBehaviour.ConsoleLogToJson());
            Debug.Log("Console Logs is Copied to Clipboard");
        }

        public override string ToString() {
            return debuggerBehaviour.ConsoleLogToJson();
        }

        /// <summary>
        /// Copy a given string.
        /// </summary>
        private void CopyText(string text) {
            TextEditor te = new TextEditor();
            te.text = text;
            te.SelectAll();
            te.Copy();
        }

    }
}
