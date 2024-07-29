using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollision : MonoBehaviour
{
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !GameManager.instance.playerInvinsibility)
        {
            GameManager.instance.playerIsHit = true;
        }
    }
}
