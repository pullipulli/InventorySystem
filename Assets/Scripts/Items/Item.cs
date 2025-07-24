using System;
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

    public virtual void DropItem()
    {
        if (_stateController == null) return;

        transform.SetParent(null);
        transform.position += new Vector3(0, 0, 10);    
        // technically it should be better to have a smooth animation instead as a fixed spawn position
        // or maybe using physics with a rigidbody..

        _stateController.ChangeState(new DroppedItemState());
    }

    public abstract void UseItem(Character owner, Action DestroyCallback);
}
