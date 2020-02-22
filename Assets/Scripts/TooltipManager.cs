using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TooltipManager : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private TextMeshProUGUI text;

    public TextMeshProUGUI Text => text;
    public void SetBackgroundColor(Color color) => background.color = color;
}
