using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TooltipManager : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private TMP_Text text;
    public TMP_Text GetText => text;
    public void SetText(string @string) => text.text = @string;
    public void SetBackgroundColor(Color color) => background.color = color;
}
