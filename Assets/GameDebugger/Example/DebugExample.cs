using System.Collections.Generic;
using InGameDebugger;
using UnityEngine;

public class DebugExample : MonoBehaviour
{
    private int counter = 0;
    private string[] foods = new string[] { "Apple", "Orange", "Noodle"};
    
    private void Start() {
        var debug = new GameDebugger();
        List<string> list = null;

        debug.Init();
        debug.AddText("In Game Debugger");
        debug.AddText(() => "Counter : " + counter);
        debug.AddButton("Add", () => { counter++; Debug.Log("Counter " + counter); });
        debug.AddDropDown(foods, (selectedIndex) => Debug.Log("I want to eat " + foods[selectedIndex]));
        debug.AddButton("Copy Logs", () => debug.CopyLogToClipboard());
        debug.AddButton("Error", () => list.Add(""));
        debug.AddConsole();
    }
}
