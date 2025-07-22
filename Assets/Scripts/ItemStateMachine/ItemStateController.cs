using UnityEngine;

public class ItemStateController : MonoBehaviour
{
    ItemState currentState;

    void Update()
    {
        currentState.UpdateState();
    }

    public void ChangeState(ItemState newState)
    {
        currentState.OnExit();
        currentState = newState;
        currentState.OnEnter(this);
    }

    public void StopStateMachine()
    {

    }
}

