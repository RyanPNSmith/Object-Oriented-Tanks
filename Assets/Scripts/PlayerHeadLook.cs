using UnityEngine;

public class PlayerHeadLook : MonoBehaviour
{
    public Transform playerHead;
    public float rotationSpeed = 5f;
    public float maxAngle = 80f;

    private Camera mainCamera;
    private Vector3 lastValidDirection;

    void Start()
    {
        mainCamera = Camera.main;
        lastValidDirection = playerHead.forward;
    }

    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = hit.point;
            targetPosition.y = playerHead.position.y; // Keep head level
            
            // Calculate direction to look at
            Vector3 direction = (targetPosition - playerHead.position).normalized;
            
            // Store last valid direction
            if (direction != Vector3.zero)
            {
                lastValidDirection = direction;
            }
            
            // Create rotation only around Y axis
            Quaternion lookRotation = Quaternion.LookRotation(lastValidDirection);
            
            // Apply the rotation in world space
            playerHead.rotation = Quaternion.Lerp(
                playerHead.rotation,
                lookRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }
} 