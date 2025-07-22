using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private ItemData _itemData;

    public ItemData ItemData {  get { return _itemData; } }

    protected ItemStateController _stateController;

    protected virtual void Awake()
    {
        if (_stateController == null)
            _stateController = gameObject.AddComponent<ItemStateController>();

        _stateController.StartStateMachine(new DroppedItemState());
    }

    public virtual void OnSelectedInInventory()
    {
        if (_stateController == null) return;

        if (_stateController.IsStarted)
            _stateController.ChangeState(new PreviewItemState());
        else _stateController.StartStateMachine(new PreviewItemState());
    }

    public abstract void UseItem();
}
