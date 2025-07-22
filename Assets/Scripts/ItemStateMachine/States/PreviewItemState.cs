using UnityEngine;

public class PreviewItemState : ItemState
{
    public override void OnEnter(ItemStateController controller)
    {
        // Show item in the first person view
        base.OnEnter(controller);
    }

    public override void OnExit()
    {
        // hide item in the firt person view
        throw new System.NotImplementedException();
    }

    public override void UpdateState(float dt) {}
}