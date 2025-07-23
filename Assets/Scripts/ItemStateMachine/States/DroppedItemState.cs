using UnityEngine;

public class DroppedItemState : ItemState
{
    private float _rotateSpeed = 0;
    private Item _item;

    public override void OnEnter(ItemStateController controller)
    {
        base.OnEnter(controller);

        if (controller.gameObject.TryGetComponent(out _item))
            _rotateSpeed = _item.ItemData.DroppedRotationSpeed;
    }

    public override void OnExit()
    {
        OnPickedUp();
    }

    public override void UpdateState(float dt)
    {
        _item.gameObject.transform.Rotate(Vector3.up, _rotateSpeed * dt);
    }

    public void OnPickedUp()
    {
        // hypotetical pick up sound and animation...
    }
}