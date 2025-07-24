using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3;
    private GameObject _itemPreviewSocket;
    public GameObject ItemPreviewSocket {get => _itemPreviewSocket; }
    private float horizontalMovement;
    private float forwardMovement;
    private new Rigidbody rigidbody;
    private GameObject _camera;

    private void Awake()
    {
        _camera = transform.GetChild(0).gameObject;
        _itemPreviewSocket = _camera.transform.GetChild(0).gameObject;
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Item>(out Item item))
        {
            Inventory.Instance.InsertItemInFirstFreeSlot(item);
        }
    }
    public void Move(Vector2 input)
    {
        horizontalMovement = input.x;
        forwardMovement = input.y;
    }

    private void FixedUpdate()
    {
        Vector3 forwardLook = _camera.transform.forward * forwardMovement;
        Vector3 horizontalLook = _camera.transform.right * horizontalMovement;
        Vector3 moveDirection = (forwardLook + horizontalLook).normalized;

        rigidbody.MovePosition(transform.position + moveSpeed * Time.deltaTime * moveDirection);
    }
}