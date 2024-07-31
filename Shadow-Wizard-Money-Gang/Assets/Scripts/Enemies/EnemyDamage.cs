using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float enemyHealth = 20;
    public bool atack1Inmune = false;
    public bool atack2Inmune = false;
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
            if (!atack1Inmune)
            {
                print("lol");
                enemyHealth = enemyHealth - GameManager.instance.playerDamage1;
                pushAwayFromPlayer(pushForceMelee);
                AudioManager.instance.PlaySfx("EnemyDeath2");
            }
        }
        if (collision.tag == "Atack2"&& !atack2Inmune)
        {
            if (!atack2Inmune)
            {
                enemyHealth = enemyHealth - GameManager.instance.playerDamage2;
                pushAwayFromPlayer(pushForceBullet);
                AudioManager.instance.PlaySfx("EnemyDeath2");
            }
        }
    }
    
    private void pushAwayFromPlayer(float pushForce)
    {
        CameraShake.Instance.shakeCamera(2f, .2f);
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
        Instantiate(damageParticlesPrefab, transform.position, Quaternion.identity);
        AudioManager.instance.PlaySfx("EnemyDeath1");
        Destroy(gameObject);
    }
   

}
