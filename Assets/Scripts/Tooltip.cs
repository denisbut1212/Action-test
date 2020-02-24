using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public enum TooltipPositionType
    {
        BottomLeft = 0,
        BottomCenter, 
        BottomRight,
        TopLeft,
        TopCenter,
        TopRight
    }

    public TooltipPositionType tooltipPosition;
    [TextArea] public string tooltipText;
    public Color backgroundColor;
    private GameObject _tooltip;
    private TooltipManager _manager;
    private RectTransform _tooltipRect;
     
    private void Start()
    {
        _tooltip = Instantiate(Resources.Load<GameObject>("Tooltip"), transform);
        _tooltipRect = _tooltip.GetComponent<RectTransform>();
        _manager = _tooltip.GetComponent<TooltipManager>();
        _manager.Text.SetText(tooltipText);
        _manager.SetBackgroundColor(backgroundColor);
        Debug.Log(_manager.Text.preferredHeight);
        var backgroundSize = new Vector2(_manager.Text.preferredWidth, _manager.Text.preferredHeight);
        _tooltipRect.sizeDelta = backgroundSize;
        _tooltip.SetActive(false);
    }

    private void ShowTooltip()
    {
       
        var transformRect = transform.GetComponent<RectTransform>().rect;
        var tooltipTransform = _tooltip.transform;
        switch (tooltipPosition)
        {
            case TooltipPositionType.BottomLeft:
                _tooltipRect.pivot = Vector2.up;
                tooltipTransform.localPosition = new Vector3(-transformRect.width / 2f, -1.2f * transformRect.height / 2f);
                break;
            case TooltipPositionType.BottomCenter:
                _tooltipRect.pivot = new Vector2(0.5f, 1);
                tooltipTransform.localPosition = new Vector3(0, -1.2f * transformRect.height / 2f);
                break;
            case TooltipPositionType.BottomRight:
                _tooltipRect.pivot = Vector2.one;
                tooltipTransform.localPosition = new Vector3(transformRect.width / 2f, -1.2f * transformRect.height / 2f);
                break;
            case TooltipPositionType.TopLeft:
                _tooltipRect.pivot = Vector2.zero;
                tooltipTransform.localPosition = new Vector3(-transformRect.width / 2f, 1.2f * transformRect.height / 2f);
                break;
            case TooltipPositionType.TopCenter:
                _tooltipRect.pivot = new Vector2(0.5f, 0);
                tooltipTransform.localPosition = new Vector3(0, 1.2f * transformRect.height / 2f);
                break;
            case TooltipPositionType.TopRight:
                _tooltipRect.pivot = Vector2.right;
                tooltipTransform.localPosition = new Vector3(transformRect.width / 2f, 1.2f * transformRect.height / 2f);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
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
