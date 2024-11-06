using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dodgeSpeed = 10f;
    public float detectionRadius = 10f;
    public float minDistanceToPlayer = 15f;
    public float maxDistanceToPlayer = 25f;
    public LayerMask bulletLayer;

    private Transform playerTransform;
    private Vector3 dodgeDirection;
    private bool isDodging = false;
    private float dodgeTimer = 0f;
    private float dodgeDuration = 0.5f;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        if (playerTransform == null) return;

        // Check for nearby bullets and dodge if necessary
        DetectAndDodgeBullets();

        // Maintain distance from player
        MaintainDistance();
    }

    void DetectAndDodgeBullets()
    {
        // Check for bullets in detection radius
        Collider[] nearbyObjects = Physics.OverlapSphere(transform.position, detectionRadius, bulletLayer);

        foreach (Collider col in nearbyObjects)
        {
            if (col.GetComponent<Rigidbody>())
            {
                // Calculate dodge direction (perpendicular to bullet trajectory)
                Rigidbody bulletRb = col.GetComponent<Rigidbody>();
                Vector3 bulletDirection = bulletRb.velocity.normalized;
                dodgeDirection = Vector3.Cross(bulletDirection, Vector3.up);

                // Randomly choose between dodging left or right
                if (Random.value > 0.5f)
                    dodgeDirection = -dodgeDirection;

                StartDodge();
                break;
            }
        }

        // Handle dodge movement
        if (isDodging)
        {
            dodgeTimer += Time.deltaTime;
            if (dodgeTimer >= dodgeDuration)
            {
                isDodging = false;
                dodgeTimer = 0f;
            }
            else
            {
                transform.position += dodgeDirection * dodgeSpeed * Time.deltaTime;
            }
        }
    }

    void MaintainDistance()
    {
        if (isDodging) return;

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;

        if (distanceToPlayer < minDistanceToPlayer)
        {
            // Move away from player
            transform.position -= directionToPlayer * moveSpeed * Time.deltaTime;
        }
        else if (distanceToPlayer > maxDistanceToPlayer)
        {
            // Move towards player
            transform.position += directionToPlayer * moveSpeed * Time.deltaTime;
        }
    }

    void StartDodge()
    {
        isDodging = true;
        dodgeTimer = 0f;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}