using UnityEngine;

// this approach is really overkill for this project because we have no animations, sounds or any other need to use a state machine
// but I think that in a real world application, this could be a perfect fit!
public class ItemStateController : MonoBehaviour
{
    private ItemState _currentState;
    private bool _isStarted = false;

    public bool IsStarted { get { return _isStarted; } }

    void Update()
    {
        if (_isStarted) _currentState.UpdateState(Time.deltaTime);
    }

    public void ChangeState(ItemState newState)
    {
        if (!IsStarted)
        {
            Debug.Log("The State Machine is not started!");
            return;
        }

        _currentState.OnExit();
        _currentState = newState;
        _currentState.OnEnter(this);
    }

    public void StopStateMachine()
    {
        _isStarted = false;
        _currentState.OnExit();
        _currentState = null;
    }

    public void StartStateMachine(ItemState initialState)
    {
        _currentState = initialState;
        _isStarted = true;
        _currentState.OnEnter(this);
    }
}

