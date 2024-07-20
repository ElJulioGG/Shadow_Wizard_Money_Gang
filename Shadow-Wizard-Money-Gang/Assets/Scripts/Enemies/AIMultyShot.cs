using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMultyShot : MonoBehaviour
{
    private GameObject player;
    public float speed;
    public float FacingThePlayerDistance;
    public float VisionRange;
    private float distance;

    //Wandering
    [SerializeField]
    float WanderingArea;
    [SerializeField]
    float StepsInWanderingArea;

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
        if (distance > VisionRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoint, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, waypoint) < StepsInWanderingArea)
            {
                setnewdestination();
            }
        }

        //Vision
        if (distance > FacingThePlayerDistance && distance < VisionRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }

    }

    void setnewdestination()
    {
        waypoint = new Vector2(transform.position.x + Random.Range(-WanderingArea, WanderingArea), transform.position.y + Random.Range(-WanderingArea, WanderingArea));
    }
}