public class DroppedItemState : ItemState
{
    private float _rotateSpeed = 0;
    public override void OnEnter(ItemStateController controller)
    {
        base.OnEnter(controller);

        if (controller.gameObject.TryGetComponent<Item>(out Item item))
            _rotateSpeed = item.ItemData.DroppedRotationSpeed;
    }

    public override void OnExit()
    {
        OnPickedUp();
    }

    public override void UpdateState()
    {
        // continue rotating the object
        throw new System.NotImplementedException();
    }

    public void OnPickedUp()
    {
        // pickup the item and then
        // if it is in the inventory change to InInventoryState
        // else change to PreviewItemState:
        _myStateController.ChangeState(new PreviewItemState());
        throw new System.NotImplementedException();
    }
}