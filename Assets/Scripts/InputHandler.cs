using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    void OnScrollWheel(InputValue value)
    {
        Inventory.Instance.OnScrollWheel(value);
    }

    void OnRightClick(InputValue value) 
    {
        Inventory.Instance.OnRightClick(value);
    }
}
