using UnityEngine;

public class DebugExample : MonoBehaviour
{

    private int counter = 0;
    
    private void Start() {
        var debug = new GameDebugger();
        debug.Init();
        debug.AddText("In Game Debugger");
        debug.AddText(() => "Counter : " + counter);
        debug.AddButton("Add", () => { counter++; Debug.Log("Counter " + counter); });
        debug.AddConsole();
    }
}
