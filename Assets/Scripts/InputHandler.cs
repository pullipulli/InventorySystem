using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputHandler : MonoBehaviour
{
    void OnScrollWheel(InputValue value)
    {
        float scrollValue = value.Get<Vector2>().y;

        Inventory.Instance.ChangeSelectedSlot(scrollValue);
    }

    void OnInteract(InputValue value) 
    {
        Inventory.Instance.UseItem();
    }
}
