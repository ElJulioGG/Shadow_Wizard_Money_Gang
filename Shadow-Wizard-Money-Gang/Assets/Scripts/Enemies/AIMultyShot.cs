using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMultyShot : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float distanceBetween;
    public float maxDistance;
    private float distance;

    //Wandering
    [SerializeField]
    float maxdistance;
    [SerializeField]
    float range;

    Vector2 waypoint;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        setnewdestination();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //Wandering
        if (distance > maxDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoint, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, waypoint) < range)
            {
                setnewdestination();
            }
        }

        //Vision
        if (distance > distanceBetween && distance < maxDistance)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }

    }

    void setnewdestination()
    {
        waypoint = new Vector2(transform.position.x + Random.Range(-maxdistance, maxdistance), transform.position.y + Random.Range(-maxdistance, maxdistance));
    }
}