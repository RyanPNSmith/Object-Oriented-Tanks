using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed of the player
    public float rotationSpeed = 10f; // How quickly the player turns
    public Transform cameraTransform; // Assign your camera in the inspector
    public Transform tankBase;  // Assign the base/body of the tank

    private void Update()
    {
        // Get input from W/S keys (up/down) and A/D keys (left/right)
        float moveZ = Input.GetAxis("Vertical");   // Forward/backward
        float moveX = Input.GetAxis("Horizontal"); // Left/right

        // Get camera's forward and right directions on the X-Z plane
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        // Normalize the vectors to maintain consistent movement speed in all directions
        forward.Normalize();
        right.Normalize();

        // Calculate the desired direction relative to the camera
        Vector3 moveDirection = forward * moveZ + right * moveX;

        // Only rotate and move if there's actual input
        if (moveDirection.magnitude > 0.1f)
        {
            // Calculate rotation for the tank base only
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            
            // Smoothly rotate the tank base towards movement direction
            tankBase.rotation = Quaternion.Lerp(
                tankBase.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );

            // Move in the direction
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}
