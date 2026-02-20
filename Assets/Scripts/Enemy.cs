using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        ContactPoint2D contact = collision.GetContact(0);

        if (contact.normal.y < -0.5f)
        {
            Vector2 bounce = Vector2.up * 10;
            collision.rigidbody.linearVelocityY = 0;
            collision.rigidbody.AddForce(
                bounce,
                ForceMode2D.Impulse);
            Die();
        } else
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(5);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
