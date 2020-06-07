using UnityEngine.UI;

public class TextUpdate {
    public Text TextValue;
    public string StrValue;
    public bool IsUpdate;

    public void Update() {
        TextValue.text = StrValue;
    }
}