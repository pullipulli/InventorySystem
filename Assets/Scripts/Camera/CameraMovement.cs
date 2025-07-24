using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 1f;

    private float horizontalRotation;
    private float verticalRotation;

    private float rotationY = 0f;

    public void RotateCamera(Vector2 input)
    {
        horizontalRotation = input.x;
        verticalRotation = input.y;
    }

    void Update()
    {
        float rotationX = transform.localEulerAngles.y + horizontalRotation * Time.deltaTime * rotateSpeed;

        rotationY += verticalRotation * rotateSpeed * Time.deltaTime;
        rotationY = Mathf.Clamp(rotationY, -90, +90);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }
}