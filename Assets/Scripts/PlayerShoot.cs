using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;      // Reference to the bullet prefab
    public Transform firingPoint;       // Reference to the firing point
    public float arcHeight = 2f;        // Height adjustment factor for the arc
    public float arcHeightChangeRate = 0.1f; // Rate of change for arc height

    public float fireRate = 0.5f;       // Time in seconds between shots
    private float nextFireTime = 0f;   // When the next shot is allowed

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;  // Set the next allowed fire time
        }

        // Adjust arc height dynamically
        if (Input.GetKey(KeyCode.E))
        {
            arcHeight += arcHeightChangeRate * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            arcHeight -= arcHeightChangeRate * Time.deltaTime;
            arcHeight = Mathf.Max(0.1f, arcHeight); // Prevent arcHeight from being too low
        }
    }

    void Shoot()
    {
        // Calculate bullet trajectory
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 targetPosition = ray.GetPoint(100);
        if (Physics.Raycast(ray, out hit))
        {
            targetPosition = hit.point;
        }

        Vector3 velocity = CalculateArcVelocity(firingPoint.position, targetPosition, arcHeight);
        Quaternion bulletRotation = Quaternion.LookRotation(velocity.normalized);
        GameObject bullet = Instantiate(bulletPrefab, firingPoint.position, bulletRotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true;
            rb.velocity = velocity;
        }
    }

    Vector3 CalculateArcVelocity(Vector3 startPoint, Vector3 endPoint, float arcHeight)
    {
        Vector3 distance = endPoint - startPoint;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0;

        float time = Mathf.Sqrt(-2 * arcHeight / Physics.gravity.y) +
                     Mathf.Sqrt(2 * (distance.y - arcHeight) / Physics.gravity.y);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * Physics.gravity.y * arcHeight);
        Vector3 velocityXZ = distanceXZ / time;

        return velocityXZ + velocityY * -Mathf.Sign(Physics.gravity.y);
    }
}
