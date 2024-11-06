using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firingPoint;
    public Transform target;
    public float arcHeight = 5f;
    public float fireRate = 2f;
    public float detectionRange = 30f;

    private float nextFireTime = 0f;

    void Update()
    {
        if (target == null) return;

        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget <= detectionRange && Time.time >= nextFireTime)
        {
            ShootAtTarget();
            nextFireTime = Time.time + fireRate;
        }
    }

    void ShootAtTarget()
    {
        Vector3 targetPosition = target.position;

        // Using the same arc calculation as PlayerShoot
        Vector3 velocity = CalculateArcVelocity(firingPoint.position, targetPosition, arcHeight);

        // Calculate rotation to face the direction of travel
        Quaternion bulletRotation = Quaternion.LookRotation(velocity.normalized);

        // Instantiate the bullet with the calculated rotation
        GameObject bullet = Instantiate(bulletPrefab, firingPoint.position, bulletRotation);

        // Set the bullet's Rigidbody to use gravity and apply calculated initial velocity
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true;
            rb.velocity = velocity;
        }
    }

    Vector3 CalculateArcVelocity(Vector3 startPoint, Vector3 endPoint, float arcHeight)
    {
        // Calculate the horizontal and vertical distances
        Vector3 distance = endPoint - startPoint;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0;

        // Calculate time to reach the target
        float time = Mathf.Sqrt(-2 * arcHeight / Physics.gravity.y) +
                    Mathf.Sqrt(2 * (distance.y - arcHeight) / Physics.gravity.y);

        // Calculate initial velocity required to reach the target in the calculated time
        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * Physics.gravity.y * arcHeight);
        Vector3 velocityXZ = distanceXZ / time;

        return velocityXZ + velocityY * -Mathf.Sign(Physics.gravity.y);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}