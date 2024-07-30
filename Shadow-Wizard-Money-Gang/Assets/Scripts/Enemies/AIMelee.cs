using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    private GameObject player;
    public float speed;
    public float VisionRange;
    private float distance;
    [SerializeField] private Animator animatorEyes;
    public float wanderingTime;
    private float timer = 0f;
    [SerializeField] private LayerMask wallLayerMask;

    // Wandering
    [SerializeField] float WanderingArea;
    [SerializeField] float StepsInWanderingArea;

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

        // Chase
        if (distance < VisionRange && CanSeePlayer(distance))
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            animatorEyes.SetBool("SlimeInRange", true);
        }
        else
        {
            // Wandering
            animatorEyes.SetBool("SlimeInRange", false);
            transform.position = Vector2.MoveTowards(transform.position, waypoint, wanderingTime * Time.deltaTime);

            if (Vector2.Distance(transform.position, waypoint) < StepsInWanderingArea)
            {
                setnewdestination();
            }
        }

        if (timer >= wanderingTime)
        {
            setnewdestination();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    private bool CanSeePlayer(float dist)
    {
        Vector2 directionToPlayer = player.transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, dist, wallLayerMask);

        return hit.collider == null;
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
}
