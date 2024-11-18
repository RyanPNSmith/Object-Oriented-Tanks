using UnityEngine;

public class ExplodingBox : MonoBehaviour
{
    public ParticleSystem explosionEffect;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a missile
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Explode();
        }
    }

    private void Explode()
    {
        // Play the explosion effect
        if (explosionEffect != null)
        {
            ParticleSystem effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            effect.Play();
            Destroy(effect.gameObject, effect.main.duration);
        }

        // Destroy the box
        Destroy(gameObject);
    }
} 