using UnityEngine;

public class BulletCollisionDetector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var enemyHealth = collision.gameObject.GetComponent<HealthManager>();
            enemyHealth.TakeDamage(50f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}