using UnityEngine;
using UnityEngine.UI;

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
    /// Add a small console window to the game.
    /// </summary>
    public void AddConsole() {
        debuggerBehaviour.InstantiateInCanvas(DebugType.Console);
    }

    #region In Development
    /// <summary>
    /// In Development
    /// </summary>
    [System.Obsolete("In Development")]
    public void AddCopyLogButton() {
        AddButton("Copy Logs", () => CopyText(""));
    }

    /// <summary>
    /// In Development
    /// </summary>
    [System.Obsolete("In Development")]
    public void CopyText(string text) {
        TextEditor te = new TextEditor();
        te.text = text;
        te.SelectAll();
        te.Copy();
    }
    #endregion

}
