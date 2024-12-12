using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 5f;
    [SerializeField] float RotationSpeed = 500f;

    CameraController cameraController;
    
    Quaternion targetRotation;

    private void Awake()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
    }

    private void Update()
    {
        float horiozontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float moveAmount = Mathf.Abs(horiozontal) + Mathf.Abs(vertical);

        var MoveInput = (new Vector3(horiozontal, 0, vertical)).normalized;
        var MoveDir = cameraController.PlanarRotation * MoveInput;

        if (moveAmount > 0)
        {
            transform.position += MoveDir * MoveSpeed * Time.deltaTime;
            targetRotation = Quaternion.LookRotation(MoveDir);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
    }
}
