using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string TooltipString { get; set; }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        TooltipShower.Instance.ShowTooltip(pointerEventData.position, TooltipString);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        TooltipShower.Instance.HideTooltip();
    }
}