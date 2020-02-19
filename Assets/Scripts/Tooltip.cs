using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [TextArea] public string tooltipText;
    public Color backgroundColor;
    private GameObject _tooltip;
    private TooltipManager _manager;
    private void Start()
    {
        _tooltip = Instantiate(Resources.Load<GameObject>("Tooltip"), transform);
        _manager = _tooltip.GetComponent<TooltipManager>();
        _manager.SetText(tooltipText);
        _manager.SetBackgroundColor(backgroundColor);
        _tooltip.SetActive(false);
    }

    private void ShowTooltip()
    {
        var backgroundSize = new Vector2(_manager.GetText.preferredWidth, _manager.GetText.preferredHeight);
        _manager.GetComponent<RectTransform>().sizeDelta = backgroundSize;
        _tooltip.SetActive(true);
    }

    private void HideTooltip()
    {
        _tooltip.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowTooltip();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HideTooltip();
    }
}
