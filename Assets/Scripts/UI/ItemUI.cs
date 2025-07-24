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
    private GameObject _itemPreviewInstance;
    private bool _isAfterAwake = false;

    public GameObject ItemPrefab { get { return _itemPrefab; } }
    public ItemData ItemData { get { return _itemData; } }
    public bool IsSelected { get  { return _isSelected; } }
    public GameObject Preview {  get { return _itemPreviewInstance; } }

    public void SetItem(Item item)
    {
        if (_itemPreviewInstance != null) Destroy(_itemPreviewInstance);

        _itemPrefab = item.gameObject;
        _itemData = item.ItemData;

        InitializeUI();
        CreateItemPreview();
    }

    public void RemoveItem()
    {
        _itemPrefab = null;
        _itemData = null;
        _itemPreviewInstance = null;
        _image.sprite = null;
    }

    private void CreateItemPreview()
    {
        if (_isAfterAwake)
        {
            _itemPrefab.transform.SetParent(Inventory.Instance.Character.ItemPreviewSocket.transform, false);
            _itemPrefab.transform.localPosition = Vector3.zero;
            _itemPreviewInstance = _itemPrefab;

            _itemPreviewInstance.GetComponent<ItemStateController>().ChangeState(new PreviewItemState());
            _itemPreviewInstance.transform.rotation = Quaternion.identity;
        }
        else
        {
            _itemPreviewInstance = Instantiate(_itemPrefab, Inventory.Instance.Character.ItemPreviewSocket.transform);

            _itemPreviewInstance.GetComponent<ItemStateController>().StartStateMachine(new PreviewItemState());
        }

        if (IsSelected) ShowPreview();
        else HidePreview();
    }

    private void InitializeUI()
    {
        _image.sprite = ItemData.Icon;
        _tempColor = _image.color;
        _tooltip = transform.AddComponent<Tooltip>();
        _tooltip.TooltipString = ItemData.Tooltip;
    }

    private void ShowPreview()
    {
        if (_itemPreviewInstance)
            _itemPreviewInstance.SetActive(true);
    }

    private void HidePreview()
    {
        if (_itemPreviewInstance)
            _itemPreviewInstance.SetActive(false);
    }


    private void Awake()
    {
        _image = GetComponent<Image>();

        if (_itemData == null)
        {
            _isAfterAwake = true;
            return;
        }

        CreateItemPreview();
        _isAfterAwake = true;
    }


    public void Select()
    {
        _isSelected = true;
        _image.color = new Color(0.5f, 0.5f, 0.5f, _tempColor.a); // gray
        _tempColor = _image.color;

        ShowPreview();
    }

    public void Unselect()
    {
        _isSelected = false;
        _image.color = new Color(1, 1, 1, _tempColor.a); // white
        _tempColor = _image.color;

        HidePreview();
    }

    public bool IsEmpty()
    {
        return _itemData == null || _itemPrefab == null;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (IsEmpty()) return;
        transform.position = eventData.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (IsEmpty()) return;
        _tempColor.a = 0.5f;
        _image.color = _tempColor;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (IsEmpty()) return;
        _tempColor.a = 1f;
        _image.color = _tempColor;
        GetComponent<RectTransform>().offsetMax = Vector2.zero;
        GetComponent<RectTransform>().offsetMin = Vector2.zero;
    }
}