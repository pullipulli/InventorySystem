public class DroppedItemState : ItemState
{
    public override void OnEnter(ItemStateController controller)
    {
        base.OnEnter(controller);
        //start rotating the object around its y axis
    }

    public override void OnExit()
    {
        OnPickedUp();
        OnSelectedInUI();
    }

    public override void UpdateState()
    {
        // continue rotating the object
        throw new System.NotImplementedException();
    }

    public void OnPickedUp()
    {
        // pickup the item and then...
        _myStateController.StopStateMachine();
    }

    public void OnSelectedInUI()
    {
        _myStateController.ChangeState(new PreviewItemState());
    }
}