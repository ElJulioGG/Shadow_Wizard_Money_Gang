using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    enum Modality{ Single, Multi}
    private GameObject player;
    private Vector2 spawnPoint;
    private float timer = 0f;
    private Rigidbody2D rb;

    [Header("Bullet Attributes")]
    public float bulletLife = 1f;
    public float speed = 1f;

    [Header("Modality")]
    [SerializeField] private Modality modality;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
        transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z);

        if(modality == Modality.Single)
        {
            rb = GetComponent<Rigidbody2D>();
            player = GameObject.FindGameObjectWithTag("Player");

            Vector3 direction = player.transform.position - transform.position;
            rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;

            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (modality == Modality.Multi)
        {
            if (timer > bulletLife) Destroy(this.gameObject);
            timer += Time.deltaTime;
            transform.position = Movement(timer);
        }
    }


    private Vector2 Movement(float timer)
    {
        // Moves right according to the bullet's rotation
        float x = timer * speed * transform.right.x;
        float y = timer * speed * transform.right.y;
        return new Vector2(x + spawnPoint.x, y + spawnPoint.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.CompareTag("Player"))
        //{
        //    Destroy(gameObject);
        //}
    }

}