using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int explosionDamage = 20;      // Only explosion damage now
    public float explosionRadius = 5f;   // Radius of explosion damage
    public ParticleSystem trailEffect;
    public ParticleSystem explosionEffect;
    public AudioSource audioSource;      // Assign your AudioSource in the inspector

    private void Start()
    {
        // Play the shooting sound when the bullet is instantiated
        if (audioSource != null)
        {
            audioSource.Play(); // Plays the assigned sound in the AudioSource
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Create explosion and damage
        Explode();

        // Destroy bullet immediately
        Destroy(gameObject);
    }

    private void Explode()
    {
        // Play explosion sound
        if (audioSource != null)
        {
            audioSource.Play(); // Play the explosion sound if the AudioSource is configured
        }

        // Play effects
        if (trailEffect != null) trailEffect.Stop();
        if (explosionEffect != null)
        {
            // Detach the explosion effect so it can finish playing
            explosionEffect.transform.parent = null;
            explosionEffect.Play();
            Destroy(explosionEffect.gameObject, explosionEffect.main.duration);
        }

        // Create explosion damage
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (var hitCollider in hitColliders)
        {
            // Check for health components in radius
            EnemyHealth enemyHealth = hitCollider.GetComponent<EnemyHealth>();
            PlayerHealth playerHealth = hitCollider.GetComponent<PlayerHealth>();

            // If not found directly, check parent
            if (enemyHealth == null)
                enemyHealth = hitCollider.GetComponentInParent<EnemyHealth>();
            if (playerHealth == null)
                playerHealth = hitCollider.GetComponentInParent<PlayerHealth>();

            // Apply explosion damage
            if (enemyHealth != null)
            {
                Debug.Log($"Explosion hit enemy for {explosionDamage} damage");
                enemyHealth.TakeDamage(explosionDamage);
            }
            else if (playerHealth != null)
            {
                Debug.Log($"Explosion hit player for {explosionDamage} damage");
                playerHealth.TakeDamage(explosionDamage);
            }
        }
    }

    // Optional: Visualize the explosion radius in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
