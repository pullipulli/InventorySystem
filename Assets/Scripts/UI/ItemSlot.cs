using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ItemSlot : MonoBehaviour, IDropHandler
{
    [HideInInspector] public int InventoryIndex;

    public void OnDrop(PointerEventData eventData)
    {
        ItemSlot otherSlot = eventData.pointerDrag.transform.parent.GetComponent<ItemSlot>();

        ItemUI myItemUI = GetItemUI();
        ItemUI otherItemUI = otherSlot.GetItemUI();

        otherItemUI.transform.SetParent(transform, false);
        myItemUI.transform.SetParent(otherSlot.transform, false);

        Inventory.Instance.SwapItems(this, otherSlot);
    }

    public ItemUI GetItemUI()
    {
        return transform.GetChild(0).GetComponent<ItemUI>();
    }
}