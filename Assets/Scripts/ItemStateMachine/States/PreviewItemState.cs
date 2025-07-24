public class PreviewItemState : ItemState
{
    public override void OnEnter(ItemStateController controller)
    {
        base.OnEnter(controller);
    }

    public override void OnExit()
    {
        OnDropItem();
    }

    public override void UpdateState(float dt) 
    {
        // hypotetical idle animation or something like that!
    }

    private void OnDropItem()
    {
        // hypotetical drop animation / sound etc..
    }
}