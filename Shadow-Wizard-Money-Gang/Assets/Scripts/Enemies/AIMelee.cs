using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    private GameObject player;
    public float speed;
    public float VisionRange;
    private float distance;
    //ublic float changePosSpeed;

    private float timer=0f;
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

        //Chase
            if (distance < VisionRange)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
            else{//wandering
                transform.position = Vector2.MoveTowards(transform.position, waypoint, speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, waypoint) < StepsInWanderingArea)
                {
                    setnewdestination();
                }
            }
            if(timer>= speed)
            {
            
                setnewdestination();
                timer = 0;
            }
            timer += Time.deltaTime;
    }
    void setnewdestination()
    {
        waypoint = new Vector2(transform.position.x + Random.Range(-WanderingArea, WanderingArea), transform.position.y + Random.Range(-WanderingArea, WanderingArea));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            
            waypoint = new Vector2(Random.Range(-WanderingArea, WanderingArea), Random.Range(-WanderingArea, WanderingArea));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Wall")
        //{
        //    if (transform.position.x > 0 && transform.position.y > 0)
        //    {
        //        waypoint = new Vector2(1 - (transform.position.x + Random.Range(-WanderingArea, WanderingArea)), 1 - (transform.position.y + Random.Range(-WanderingArea, WanderingArea)));
        //    }
        //    if (transform.position.x < 0 && transform.position.y > 0)
        //    {
        //        waypoint = new Vector2(1 + (transform.position.x + Random.Range(-WanderingArea, WanderingArea)), 1 - (transform.position.y + Random.Range(-WanderingArea, WanderingArea)));
        //    }
        //    if (transform.position.x > 0 && transform.position.y < 0)
        //    {
        //        waypoint = new Vector2(1 - (transform.position.x + Random.Range(-WanderingArea, WanderingArea)), 1 + (transform.position.y + Random.Range(-WanderingArea, WanderingArea)));
        //    }
        //    if (transform.position.x < 0 && transform.position.y < 0)
        //    {
        //        waypoint = new Vector2(1 + (transform.position.x + Random.Range(-WanderingArea, WanderingArea)), 1 + (transform.position.y + Random.Range(-WanderingArea, WanderingArea)));
        //    }
        //}
    }

}
