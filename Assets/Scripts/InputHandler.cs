using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputHandler : MonoBehaviour
{
    public InputHandler Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else Destroy(this);
    }

    private bool _isInventoryFocused = false;
    void OnScrollWheel(InputValue value)
    {
        float scrollValue = value.Get<Vector2>().y;

        Inventory.Instance.ChangeSelectedSlot(scrollValue);
    }

    void OnInteract(InputValue value) 
    {
        if (_isInventoryFocused) return;

        Inventory.Instance.UseItem();
    }

    void OnMove()
    {
        if (_isInventoryFocused) return;
    }

    void OnLook()
    {
        if (_isInventoryFocused) return;
    }

    void OnDrop()
    {

    }

    void OnInventory()
    {
        if (_isInventoryFocused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            _isInventoryFocused = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            _isInventoryFocused = true;
        }
    }
}
