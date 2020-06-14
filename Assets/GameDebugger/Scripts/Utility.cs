using UnityEngine;

public static class Utility {
    
    public static string ToJson(this ConsoleLog consoleLog) {
        return JsonUtility.ToJson(consoleLog, true);
    }
}