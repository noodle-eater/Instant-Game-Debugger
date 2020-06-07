using UnityEngine;
using UnityEngine.UI;

public class GameDebugger
{

    private GameDebugBehaviour debuggerBehaviour;
    private int counter = 0;

    public void Init() {
        debuggerBehaviour = GameDebugBehaviour.Init();
    }

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

    public void AddSeparator() {
        debuggerBehaviour.InstantiateInCanvas(DebugType.Separator);
    }

    public void AddConsole() {
        debuggerBehaviour.InstantiateInCanvas(DebugType.Console);
    }

}
