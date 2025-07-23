using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ItemUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private ItemData _itemData;
    [SerializeField] private GameObject _itemPrefab;
    private bool _isSelected = false;
    private Image _image;
    private Color _tempColor = Color.white;
    private Tooltip _tooltip;

    public GameObject ItemPrefab { get { return _itemPrefab; } }
    public ItemData ItemData { get { return _itemData; } }
    public bool IsSelected { get  { return _isSelected; } }

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
        _tempColor = _image.color;
        _tooltip = transform.AddComponent<Tooltip>();
        _tooltip.TooltipString = ItemData.Tooltip;
    }

    public void Select()
    {
        _isSelected = true;
        _image.color = new Color(0.5f, 0.5f, 0.5f, _tempColor.a); // gray
        _tempColor = _image.color;
    }

    public void Unselect()
    {
        _isSelected = false;
        _image.color = new Color(1, 1, 1, _tempColor.a); // white
        _tempColor = _image.color;
    }

    public bool IsEmpty()
    {
        return _itemData == null || _itemPrefab == null;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _tempColor.a = 0.5f;
        _image.color = _tempColor;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _tempColor.a = 1f;
        _image.color = _tempColor;
        GetComponent<RectTransform>().offsetMax = Vector2.zero;
        GetComponent<RectTransform>().offsetMin = Vector2.zero;
    }
}