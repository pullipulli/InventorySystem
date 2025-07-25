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

    [SerializeField] private GameObject _character;
    private bool _isInventoryFocused = false;

    // mouse scroll wheel
    void OnScrollWheel(InputValue value)
    {
        float scrollValue = value.Get<Vector2>().y;

        Inventory.Instance.ChangeSelectedSlot(scrollValue);
    }

    // right mouse button
    void OnInteract(InputValue value) 
    {
        if (_isInventoryFocused) return;

        Inventory.Instance.UseSelectedItem();
    }

    // WASD keys
    void OnMove(InputValue value)
    {
        if (_isInventoryFocused) return;

        Vector2 movement = value.Get<Vector2>();

        _character.GetComponent<Character>().Move(movement);
    }

    // mouse movement
    void OnLook(InputValue value)
    {
        if (_isInventoryFocused) return;

        Vector2 movement = value.Get<Vector2>();

        Camera.main.GetComponent<CameraMovement>().RotateCamera(movement);
    }

    // Q key
    void OnDrop(InputValue value)
    {
        Inventory.Instance.DropSelectedItem();
    }

    // I key
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
