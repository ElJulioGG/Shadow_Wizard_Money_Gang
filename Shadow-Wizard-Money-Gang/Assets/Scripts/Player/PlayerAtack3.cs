using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            print("work");
            Rigidbody2D bulletRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (bulletRb != null)
            {
                bulletRb.velocity = -bulletRb.velocity; // Invert the bullet's velocity
            }

        }
    }
}
