using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShoot : MonoBehaviour
{
    private GameObject player;
    public float speed;
    public float distanceBetween;
    public float maxDistance;


    private float distance;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        //Preferencia estetica
        if(distance < distanceBetween)
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

        //Vision
        if(distance > distanceBetween && distance < maxDistance)
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            
        }

    }
}
