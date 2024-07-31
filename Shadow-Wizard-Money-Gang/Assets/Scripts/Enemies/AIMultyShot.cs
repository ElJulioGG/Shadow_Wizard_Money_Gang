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
    public float wanderingTime;
    private float timer = 0f;
    //Wandering
    [SerializeField] private Animator animatorEyes;
    [SerializeField] private Animator animatorSprite;

    [SerializeField]
    float WanderingArea;
    [SerializeField]
    float StepsInWanderingArea;
    [SerializeField] private LayerMask wallLayerMask;
    Vector2 waypoint;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        setnewdestination();
    }

    // Update is called once per frame
    void Update()
    {

        float rotz = transform.rotation.eulerAngles.z;

        if (rotz >= 90 && rotz <= 270)
        {
            print(rotz);
            animatorEyes.SetBool("Reverse", true);
            animatorSprite.SetBool("Reverse", true);
        }
        else
        {
            animatorEyes.SetBool("Reverse", false);
            animatorSprite.SetBool("Reverse", false);
        }


        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //Wandering
        if (distance > VisionRange || CanSeePlayer(distance) == false)
        {
            animatorEyes.SetBool("GhostInRange", false);
            transform.position = Vector2.MoveTowards(transform.position, waypoint, wanderingTime * Time.deltaTime);
            if (Vector2.Distance(transform.position, waypoint) < StepsInWanderingArea)
            {
                setnewdestination();
            }
        }

        //Vision
        if (distance > FacingThePlayerDistance && distance < VisionRange && CanSeePlayer(distance))
        {
            animatorEyes.SetBool("GhostInRange", true);
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
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