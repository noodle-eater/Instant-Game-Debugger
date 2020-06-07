using UnityEngine;
using UnityEngine.UI;

public class GameDebugger
{

    private GameDebugBehaviour debuggerBehaviour;
    private int counter = 0;

    public void Init() {
        debuggerBehaviour = GameObject.FindObjectOfType<GameDebugBehaviour>();
    }

    public void AddButton(string buttonName, System.Action OnClicked) {
        var go = debuggerBehaviour.InstantiateInCanvas(DebugType.Button);
        go.name = counter + " - " + buttonName;
        go.GetComponent<Button>().onClick.AddListener(() => OnClicked());
        go.GetComponentInChildren<Text>().text = buttonName;
    }

    public void AddText(string text, System.Func<string> GetText) {
        var go = debuggerBehaviour.InstantiateInCanvas(DebugType.Text);
        var uiText = go.GetComponent<Text>();
        uiText.text = GetText?.Invoke();
        debuggerBehaviour.OnUpdate += () => uiText.text = GetText?.Invoke();
        // debuggerBehaviour.TextUpdates.Add(
        //     new TextUpdate { 
        //         TextValue = uiText,
        //         StrValue = text,
        //         IsUpdate = isUpdate
        //     }
        // );
    }

    public void AddSeparator() {
        debuggerBehaviour.InstantiateInCanvas(DebugType.Separator);
    }

    public void AddConsole() {
        debuggerBehaviour.InstantiateInCanvas(DebugType.Console);
    }

}
