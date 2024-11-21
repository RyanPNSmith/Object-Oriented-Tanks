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
        Debug.Log("Explode method called");
        // Play the explosion effect
        if (explosionEffect != null)
        {
            // Instantiate the effect slightly above the box
            Vector3 effectPosition = transform.position + Vector3.up * 0.5f; // Adjust the height as needed
            ParticleSystem effect = Instantiate(explosionEffect, effectPosition, Quaternion.identity);
            effect.Play();
            Destroy(effect.gameObject, effect.main.duration);
        }

        // Destroy the box
        Destroy(gameObject);
    }
}