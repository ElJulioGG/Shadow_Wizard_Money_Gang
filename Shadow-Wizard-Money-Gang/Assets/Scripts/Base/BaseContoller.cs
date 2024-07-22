using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseContoller : MonoBehaviour
{
    [SerializeField] private float health;

    public Shake shake;

    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            shake.StartShake();
        }
        if (collision.tag == "Melee")
        {
            shake.StartShake();
        }
    }
}
