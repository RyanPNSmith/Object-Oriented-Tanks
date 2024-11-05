using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Reference to the bullet prefab
    public GameObject bulletPrefab;
    // Reference to the firing point
    public Transform firingPoint;
    // Height adjustment factor for the arc
    public float arcHeight = 2f;

    [Header("Fire Rate")]
    public float fireRate = 0.5f;  // Time in seconds between shots
    private float nextFireTime = 0f;  // When the next shot is allowed

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime) // Check if enough time has passed
        {
            Shoot();
            nextFireTime = Time.time + fireRate;  // Set the next allowed fire time
        }
    }

    void Shoot()
    {
        // Get the mouse position in world space
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Vector3 targetPosition;

        // Check if the ray hits something in the scene
        if (Physics.Raycast(ray, out hit))
        {
            // If it hits something, use the hit point as the target position
            targetPosition = hit.point;
        }
        else
        {
            // If it doesn't hit anything, set a point far in the distance as the target
            targetPosition = ray.GetPoint(100); // Adjust the distance as needed
        }

        // Calculate the initial velocity needed to hit the target with an arc
        Vector3 velocity = CalculateArcVelocity(firingPoint.position, targetPosition, arcHeight);

        // Calculate rotation to face the direction of travel
        Quaternion bulletRotation = Quaternion.LookRotation(velocity.normalized);

        // Instantiate the bullet with the calculated rotation
        GameObject bullet = Instantiate(bulletPrefab, firingPoint.position, bulletRotation);

        // Set the bullet's Rigidbody to use gravity and apply calculated initial velocity
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true; // Enable gravity
            rb.velocity = velocity; // Apply calculated velocity
        }
    }

    Vector3 CalculateArcVelocity(Vector3 startPoint, Vector3 endPoint, float arcHeight)
    {
        // Calculate the horizontal and vertical distances
        Vector3 distance = endPoint - startPoint;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0;

        // Calculate time to reach the target
        float time = Mathf.Sqrt(-2 * arcHeight / Physics.gravity.y) + Mathf.Sqrt(2 * (distance.y - arcHeight) / Physics.gravity.y);

        // Calculate initial velocity required to reach the target in the calculated time
        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * Physics.gravity.y * arcHeight);
        Vector3 velocityXZ = distanceXZ / time;

        return velocityXZ + velocityY * -Mathf.Sign(Physics.gravity.y);
    }
}
