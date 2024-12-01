using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float rotationSpeed = 2f;

    [Header("Combat Settings")]
    [SerializeField] private float detectionRange = 10f;
    [SerializeField] private float shootingRange = 7f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private float fireRate = 2f;
    [SerializeField] private float arcHeight = 5f; // Height of the arc for the projectile

    [Header("References")]
    public Transform player; // Assign the player object in the Unity Inspector

    private float nextFireTime = 0f;

    private void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            RotateTowardsPlayer();

            if (distanceToPlayer > shootingRange)
            {
                MoveTowardsPlayer();
            }
            else if (Time.time >= nextFireTime)
            {
                ShootAtTarget();
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    private void RotateTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z)); // Ignore Y-axis
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z); // Lock Y-axis
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    private void ShootAtTarget()
    {
        if (!bulletPrefab || !firingPoint) return;

        // Calculate arc velocity
        Vector3 velocity = CalculateArcVelocity(firingPoint.position, player.position, arcHeight);

        // Create and fire the bullet
        GameObject bullet = Instantiate(bulletPrefab, firingPoint.position, Quaternion.LookRotation(velocity.normalized));

        if (bullet.TryGetComponent(out Rigidbody rb))
        {
            rb.useGravity = true; // Enable gravity for the arc
            rb.velocity = velocity;
        }
    }

    private Vector3 CalculateArcVelocity(Vector3 startPoint, Vector3 endPoint, float height)
    {
        Vector3 distance = endPoint - startPoint;
        Vector3 horizontalDistance = new Vector3(distance.x, 0, distance.z);

        float time = Mathf.Sqrt(-2 * height / Physics.gravity.y) +
                     Mathf.Sqrt(2 * (distance.y - height) / Physics.gravity.y);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * Physics.gravity.y * height);
        Vector3 velocityXZ = horizontalDistance / time;

        return velocityXZ + velocityY * -Mathf.Sign(Physics.gravity.y);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
