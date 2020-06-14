using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InGameDebugger {

    internal delegate void OnUpdateEvent();

    internal class GameDebugBehaviour : MonoBehaviour {
        
        internal OnUpdateEvent OnUpdate;

        private GameObject _consoleContent;
        private DebugUI _debugUI = new DebugUI();
        private ConsoleLog _consoleLogs = new ConsoleLog();

        private int _counter = 0;

        internal static GameDebugBehaviour Init() {
            Instantiate(Resources.Load<GameObject>("Debug Canvas"));

            if(!GameObject.Find("EventSystem")) {
                Instantiate(Resources.Load<GameObject>("EventSystem"));
            }

            return FindObjectOfType<GameDebugBehaviour>();
        }

        private void Awake() {
            _debugUI.Init();
            Application.logMessageReceived += HandleLog;
        }

        private void Update() {
            OnUpdate?.Invoke();
        }

        internal GameObject InstantiateInCanvas(DebugType type) {
            GameObject go = null;
            switch(type) {
                case DebugType.Button : 
                    go = Instantiate(_debugUI.Button);
                    break;
                case DebugType.Separator : 
                    go = Instantiate(_debugUI.Separator);
                    break;
                case DebugType.Text : 
                    go = Instantiate(_debugUI.Text);
                    break;
                case DebugType.Dropdown:
                    go = Instantiate(_debugUI.Dropdown);
                    break;
                case DebugType.Console : 
                    go = Instantiate(_debugUI.Console);
                    if(_consoleContent == null) {
                        _consoleContent = GameObject.Find("Console Content");
                    }
                    break;
            }

            if(go != null)
                go.transform.SetParent(transform, false);
            return go;
        }

        private void HandleLog(string logString, string stackTrace, LogType type)
        {
            if (_consoleContent == null)
                return;

            AddConsoleLog(logString, stackTrace, type);

            GameObject log = Instantiate(_debugUI.ConsoleText);
            log.name = type + " - " + ++_counter;
            log.transform.SetParent(_consoleContent.transform, false);
            var LogText = log.GetComponent<Text>();

            FormatLog(logString, stackTrace, type, LogText);
        }

        private void FormatLog(string logString, string stackTrace, LogType type, Text LogText)
        {
            switch (type)
            {
                case LogType.Error:
                    LogText.text = "<color=red>" + type + " >> " + logString + "\n" + stackTrace + "</color>";
                    break;
                case LogType.Exception:
                    LogText.text = "<color=red>" + type + " >> " + logString + "\n" + stackTrace + "</color>";
                    break;
                case LogType.Warning:
                    LogText.text = "<color=yellow>" + type + " >> " + logString + "\n" + stackTrace + "</color>";
                    break;
                case LogType.Log:
                    LogText.text = type + " >> " + logString;
                    break;
                case LogType.Assert:
                    LogText.text = type + " >> " + logString;
                    break;
            }
        }

        private void AddConsoleLog(string logString, string stackTrace, LogType type) {
            _consoleLogs.logs.Add(new Log {
                LogString = logString,
                StackTrace = stackTrace,
                LogType = type.ToString()
            });
        }

        internal string ConsoleLogToJson()
        {
            return _consoleLogs.ToJson();
        }

    }
}