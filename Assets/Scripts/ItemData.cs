using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] private string _itemName;
    [SerializeField] private Sprite _icon;
    [SerializeField, TextArea] private string _tooltip;
    [SerializeField] private GameObject _previewPrefab;
    [SerializeField] private GameObject _droppedPrefab;
    [SerializeField] private int _stackSize;

    public string ItemName { get => _itemName; }
    public Sprite Icon { get => _icon; }
    public string Tooltip { get => _tooltip; }
    public GameObject Preview { get => _previewPrefab; }
    public GameObject Droppped { get => _droppedPrefab; }
    public int StackSize { get => _stackSize; }
}
