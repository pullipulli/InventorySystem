public abstract class ItemState
{
    protected ItemStateController _myStateController;
    public virtual void OnEnter(ItemStateController controller)
    {
        _myStateController = controller;
    }

    public abstract void UpdateState();

    public abstract void OnExit();
}