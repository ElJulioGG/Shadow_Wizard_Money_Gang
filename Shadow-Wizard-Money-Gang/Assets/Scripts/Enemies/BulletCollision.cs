using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !GameManager.instance.playerInvinsibility)
        {
            GameManager.instance.playerIsHit = true;
            Destroy(this.gameObject);
        }
        if (collision.tag == "Wall")
        {
            
            Destroy(this.gameObject);
        }
        if (collision.tag == "Atack3")
        {
          
           
            rb.angularVelocity = -rb.angularVelocity;
        }


    }
}
