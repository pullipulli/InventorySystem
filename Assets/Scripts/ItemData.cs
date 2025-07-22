using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] private string _itemName;
    [SerializeField] private Sprite _icon;
    [SerializeField, TextArea] private string _tooltip;
    [SerializeField, Min(0)] private int _maxStackSize;
    [SerializeField, Min(0)] private float _droppedRotationSpeed = 0f;

    public string ItemName { get => _itemName; }
    public Sprite Icon { get => _icon; }
    public string Tooltip { get => _tooltip; }
    public int MaxStackSize { get => _maxStackSize; }
    public float DroppedRotationSpeed { get => _droppedRotationSpeed; }
}
