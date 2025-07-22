using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ItemSlot : MonoBehaviour
{
    [SerializeField] private ItemData _itemData;
    [SerializeField] private GameObject _itemPrefab;
    private bool _isSelected = false;
    private Image _image;

    public GameObject ItemPrefab { get { return _itemPrefab; } }
    public ItemData ItemData { get { return _itemData; } }
    public bool IsSelected { get  { return _isSelected; } }

    public int SlotIndex;

    public void SetItem(Item item)
    {
        _itemPrefab = item.gameObject;
        _itemData = item.ItemData;
    }


    private void Awake()
    {
        _image = GetComponent<Image>();

        if (_itemData == null) return;

        _image.sprite = ItemData.Icon;
    }

    public void Select()
    {
        _isSelected = true;
        _image.color = Color.gray;
    }

    public void Unselect()
    {
        _isSelected = false;
        _image.color = Color.white;
    }
}