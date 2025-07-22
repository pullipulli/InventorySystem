public class DeloreanItem : Item
{
    public override void UseItem()
    {
        _stateController.StopStateMachine();
        throw new System.NotImplementedException();
    }
}