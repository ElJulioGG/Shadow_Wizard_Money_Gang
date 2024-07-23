using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionTutorial : MonoBehaviour
{
    private GameObject player;
    private GameObject respawn;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        respawn = GameObject.FindGameObjectWithTag("TutorialRespawn");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !GameManager.instance.playerInvinsibility)
        {
            player.transform.position = respawn.transform.position;
            GameManager.instance.playerIsHit = true;
            GameManager.instance.playerHealth = GameManager.instance.playerMaxHealth;
            Destroy(this.gameObject);
        }
    }
}
