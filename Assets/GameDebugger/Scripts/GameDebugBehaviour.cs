using System.Collections.Generic;
using UnityEngine;

public delegate void OnUpdateEvent();

public class GameDebugBehaviour : MonoBehaviour {
    
    public OnUpdateEvent OnUpdate;

    public GameDebugBehaviour Instance { get; private set; }
    public List<TextUpdate> TextUpdates { get; private set; }
    public GameObject DebugContent { get; private set; }
    public GameObject ConsoleContent { get; private set; }

    private GameObject debugButton;
    private GameObject debugText;
    private GameObject debugSeparator;
    private GameObject debugConsole;
    private GameObject consoleText;


    private const string DEBUGCONTENTNAME = "Debug Content";
    private const string CONSOLECONTENTNAME = "Console Content";
    

    private void Awake() {
        Instance = this;
        DebugContent = gameObject;
        ConsoleContent = GameObject.Find(CONSOLECONTENTNAME);
        TextUpdates = new List<TextUpdate>();
    }

    private void Update() {
        
    }

    public GameObject InstantiateInCanvas(DebugType type) {
        switch(type) {
            case DebugType.Button : return Instantiate(debugButton);
            case DebugType.Separator : return Instantiate(debugSeparator);
            case DebugType.Text : return Instantiate(debugText);
            case DebugType.Console : return Instantiate(debugConsole);
            default: return null;
        }
    }

    public void UpdateText() {
        foreach(var item in TextUpdates) {
            if(item.IsUpdate) {
                item.Update();
            }
        }
    }

}