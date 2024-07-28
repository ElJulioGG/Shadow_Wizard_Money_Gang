using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionTutorial : MonoBehaviour
{
    private GameObject player;
    private GameObject respawn;
    [SerializeField]private string respawnName;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        respawn = GameObject.FindGameObjectWithTag(respawnName);
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
