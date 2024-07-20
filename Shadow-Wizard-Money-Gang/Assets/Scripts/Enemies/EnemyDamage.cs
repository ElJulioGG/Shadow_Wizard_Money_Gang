using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float enemyHealth = 20;

    public GameObject damageParticlesPrefab;
    public float pushForceMelee= 50f; // Add this line
    public float pushForceBullet = 25f; // Add this line

    private GameObject player;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        if (enemyHealth <= 0)
        {
            death();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Atack1")
        {
            enemyHealth = enemyHealth - GameManager.instance.playerDamage1;
            pushAwayFromPlayer(pushForceMelee);
        }
        if (collision.tag == "Atack2")
        {
            enemyHealth = enemyHealth - GameManager.instance.playerDamage2;
            pushAwayFromPlayer(pushForceBullet);
            
        }
    }
    
    private void pushAwayFromPlayer(float pushForce)
    {
        if (player != null && rb != null)
        {
            Vector2 pushDirection = (transform.position - player.transform.position).normalized;
            rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
        }
    }
    private void InstantiateParticles(Vector2 direction) // Add this method
    {
        if (damageParticlesPrefab != null)
        {
            GameObject particles = Instantiate(damageParticlesPrefab, transform.position, Quaternion.identity);
            ParticleSystem particleSystem = particles.GetComponent<ParticleSystem>();
            if (particleSystem != null)
            {
                var shape = particleSystem.shape;
                shape.rotation = new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg); // Set the direction
            }
            Destroy(particles, particleSystem.main.duration); // Destroy particles after their duration
        }
    }
    private void death()
    {
        Destroy(gameObject);
    }
   

}
