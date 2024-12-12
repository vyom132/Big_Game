using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform FollowTarget;
    [SerializeField] float distance = 5;
    [SerializeField] float RotationSpeed = 2f;
    [SerializeField] float MinVerticalAngle = -20;
    [SerializeField] float MaxVerticalAngle = 45;
    [SerializeField] Vector2 FramingOffset;

    float rotationX;
    float rotationY;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        rotationX += Input.GetAxis("Mouse Y") * RotationSpeed;
        rotationX = Mathf.Clamp(rotationX, MinVerticalAngle, MaxVerticalAngle);

        rotationY += Input.GetAxis("Mouse X") * RotationSpeed;

        var targetRotation = Quaternion.Euler(rotationX, rotationY, 0);
        var focusPosition = FollowTarget.position + new Vector3(FramingOffset.x, FramingOffset.y);

        transform.position = focusPosition - targetRotation * new Vector3(0, 0, distance);
        transform.rotation = targetRotation;
       
    }

    public Quaternion PlanarRotation => Quaternion.Euler(0,rotationY, 0);

    public Quaternion GetPlanarRotation()
    {
        return Quaternion.Euler(0, rotationY, 0);
    }
}
