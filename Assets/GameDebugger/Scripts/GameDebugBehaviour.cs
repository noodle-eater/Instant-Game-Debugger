using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void OnUpdateEvent();

public class GameDebugBehaviour : MonoBehaviour {
    
    public OnUpdateEvent OnUpdate;

    private GameObject DebugContent;
    private GameObject ConsoleContent;

    private GameObject debugButton;
    private GameObject debugText;
    private GameObject debugSeparator;
    private GameObject debugConsole;
    private GameObject consoleText;

    private ConsoleLog consoleLogs = new ConsoleLog();

    private int counter = 0;

    public static GameDebugBehaviour Init() {
        Instantiate(Resources.Load<GameObject>("Debug Canvas"));

        if(!GameObject.Find("EventSystem")) {
            Instantiate(Resources.Load<GameObject>("EventSystem"));
        }

        return FindObjectOfType<GameDebugBehaviour>();
    }

    private void Awake() {
        DebugContent = gameObject;

        debugButton = Resources.Load<GameObject>("Debug Button");
        debugText = Resources.Load<GameObject>("Debug Text");
        debugSeparator = Resources.Load<GameObject>("Debug Separator");
        debugConsole = Resources.Load<GameObject>("Debug Console");
        consoleText = Resources.Load<GameObject>("Console Text");

        Application.logMessageReceived += HandleLog;
    }

    private void Update() {
        OnUpdate?.Invoke();
    }

    public GameObject InstantiateInCanvas(DebugType type) {
        GameObject go = null;
        switch(type) {
            case DebugType.Button : 
                go = Instantiate(debugButton);
                break;
            case DebugType.Separator : 
                go = Instantiate(debugSeparator);
                break;
            case DebugType.Text : 
                go = Instantiate(debugText);
                break;
            case DebugType.Console : 
                go = Instantiate(debugConsole);
                if(ConsoleContent == null) {
                    ConsoleContent = GameObject.Find("Console Content");
                }
                break;
        }

        if(go != null)
            go.transform.SetParent(DebugContent.transform, false);
        return go;
    }

    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        if (ConsoleContent == null)
            return;

        AddConsoleLog(logString, stackTrace, type);

        GameObject log = Instantiate(consoleText);
        log.name = type + " - " + ++counter;
        log.transform.SetParent(ConsoleContent.transform, false);
        var LogText = log.GetComponent<Text>();

        FormatLog(logString, stackTrace, type, LogText);
    }

    private void FormatLog(string logString, string stackTrace, LogType type, Text LogText)
    {
        switch (type)
        {
            case LogType.Error:
                LogText.text = "\t<color=red>" + type + " >> " + logString + "\n" + stackTrace + "</color>";
                break;
            case LogType.Exception:
                LogText.text = "\t<color=red>" + type + " >> " + logString + "\n" + stackTrace + "</color>";
                break;
            case LogType.Warning:
                LogText.text = "\t<color=yellow>" + type + " >> " + logString + "\n" + stackTrace + "</color>";
                break;
            case LogType.Log:
                LogText.text = "\t" + type + " >> " + logString;
                break;
            case LogType.Assert:
                LogText.text = "\t" + type + " >> " + logString;
                break;
        }
    }

    private void AddConsoleLog(string logString, string stackTrace, LogType type) {
        consoleLogs.logs.Add(new Log {
            LogString = logString,
            StackTrace = stackTrace,
            LogType = type.ToString()
        });
    }

}