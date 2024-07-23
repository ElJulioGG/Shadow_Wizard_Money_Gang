using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    
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

    }
}
