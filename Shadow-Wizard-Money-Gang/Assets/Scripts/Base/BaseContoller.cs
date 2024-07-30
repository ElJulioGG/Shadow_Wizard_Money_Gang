using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class BaseContoller : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float damageRecievedProyectile;
    [SerializeField] private float damageRecievedMeleee;
    [SerializeField] private Text textForeground;
    [SerializeField] private Text text2;
    [SerializeField] private float maxHealth;

    [SerializeField] private float meleeDamageCooldown = 1f;
    private float timer = 0f;
    public Shake shake;

    private void Start()
    {
        maxHealth = health;
    }
    private void Update()
    {
        if(health<= (maxHealth) / 2)
        {
            textForeground.color = Color.yellow;
        }
        if (health <= (maxHealth) / 4)
        {
            textForeground.color = Color.red;
        }
        if (health<= 0)
        {
            GameManager.instance.playerDied = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            health = health - damageRecievedProyectile;
                shake.StartShake();
              textForeground.text = health.ToString();
              text2.text = health.ToString();
        }
       
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.tag == "Melee" && (timer >= meleeDamageCooldown))
        {
            health = health - damageRecievedMeleee;
            shake.StartShake();
            textForeground.text = health.ToString();
            text2.text = health.ToString();
            timer = 0f;
        }
        timer += Time.deltaTime;
    }
}
