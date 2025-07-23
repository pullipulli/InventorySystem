using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3;
    [SerializeField] private float rotateSpeed = 1f;

    float horizontalMovement;
    float forwardMovement;

    float horizontalRotation;
    float verticalRotation;

    public void MoveCamera(Vector2 input)
    {
        horizontalMovement = input.x;
        forwardMovement = input.y;
    }

    public void RotateCamera(Vector2 input)
    {
        horizontalRotation = input.x;
        verticalRotation = input.y;
    }

    void Update()
    {
        if (horizontalMovement != 0 || forwardMovement != 0)
        {
            transform.position += moveSpeed * new Vector3(horizontalMovement, 0, forwardMovement) * Time.deltaTime;
        }

        if (horizontalRotation != 0 || verticalRotation != 0)
        {
            transform.rotation *= Quaternion.Euler(rotateSpeed * Time.deltaTime * new Vector3(verticalRotation, horizontalRotation, 0));
        }
    }
}