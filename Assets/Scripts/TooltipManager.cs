using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TooltipManager : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private TMP_Text Text;
    public TMP_Text GetText => Text;
    public void SetText(string @string) => Text.text = @string;
    public void SetBackgroundColor(Color color) => background.color = color;
}
