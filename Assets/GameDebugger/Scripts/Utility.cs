using UnityEngine;

namespace InGameDebugger {    
    internal static class Utility {
        
        internal static string ToJson(this ConsoleLog consoleLog) {
            return JsonUtility.ToJson(consoleLog, true);
        }
    }
}