using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 3f;
    public float rotationSpeed = 2f;
    public float detectionRange = 10f;
    public float shootingRange = 7f;

    [Header("Combat Settings")]
    public GameObject bulletPrefab;
    public Transform firingPoint;
    public float fireRate = 2f;
    public float arcHeight = 5f;

    private Transform player;
    private float nextFireTime = 0f;
    private Vector3 randomPosition;
    private bool isWandering = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        SetNewRandomDestination();
    }

    private void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            isWandering = false;
            // Combat behavior
            if (distanceToPlayer <= shootingRange && Time.time >= nextFireTime)
            {
                ShootAtTarget();
                nextFireTime = Time.time + fireRate;
            }
            // Move and rotate towards player
            Vector3 direction = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            Wander();
        }
    }

    private void SetNewRandomDestination()
    {
        Vector2 randomCircle = Random.insideUnitCircle * 10f;
        randomPosition = new Vector3(
            transform.position.x + randomCircle.x,
            transform.position.y,
            transform.position.z + randomCircle.y
        );
        isWandering = true;
    }

    private void Wander()
    {
        if (isWandering)
        {
            transform.position = Vector3.MoveTowards(transform.position, randomPosition, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, randomPosition) < 0.1f)
            {
                SetNewRandomDestination();
            }
        }
    }

    private void ShootAtTarget()
    {
        Vector3 velocity = CalculateArcVelocity(firingPoint.position, player.position, arcHeight);
        GameObject bullet = Instantiate(bulletPrefab, firingPoint.position, Quaternion.LookRotation(velocity.normalized));
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true;
            rb.velocity = velocity;
        }
    }

    private Vector3 CalculateArcVelocity(Vector3 startPoint, Vector3 endPoint, float height)
    {
        Vector3 distance = endPoint - startPoint;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0;

        float time = Mathf.Sqrt(-2 * height / Physics.gravity.y) +
                    Mathf.Sqrt(2 * (distance.y - height) / Physics.gravity.y);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * Physics.gravity.y * height);
        Vector3 velocityXZ = distanceXZ / time;

        return velocityXZ + velocityY * -Mathf.Sign(Physics.gravity.y);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingRange);

        if (isWandering)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(randomPosition, 0.5f);
            Gizmos.DrawLine(transform.position, randomPosition);
        }
    }
} 