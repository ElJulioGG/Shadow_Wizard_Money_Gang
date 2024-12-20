using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private GameObject Player;
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    
    public int damage = 100;
    public int magnitude = 15;
    public GameObject breakParticles;
    [SerializeField] private float destroyTime = 1f;


    // Start is called before the first frame update
    void Start()
    {
        //AudioManager.instance.PlaySfx("PearlThrow");
        Player = GameObject.FindGameObjectWithTag("Player");
        playerRb = Player.GetComponent<Rigidbody2D>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * GameManager.instance.playerBulletForce;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        Invoke("destroyEvent", destroyTime); ;

        Vector2 recoilDirection = -new Vector2(direction.x, direction.y).normalized;
        playerRb.AddForce(recoilDirection * magnitude, ForceMode2D.Impulse);
        AudioManager.instance.PlaySfxLoop1("AirTimeProyectile");
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Player.transform.position = gameObject.transform.position;
        //if (GameManager.instance.playerDied)
        //{
        //    destroyEvent();
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
        }
        else
        {
            Player.transform.position = gameObject.transform.position;
            if (collision.gameObject.CompareTag("platform"))
            {
                Player.transform.position = gameObject.transform.position;
                print("Yup");
                //AudioManager.instance.PlaySfx("PearlLand");
                
            }
            destroyEvent();
           ;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy"|| collision.gameObject.tag == "Melee")&& !GameManager.instance.playerPiercingShot)
        {
            destroyEvent();
        }
    }

    private void destroyEvent()
    {
        // AudioManager.instance.PlaySfx("Negative");
        Instantiate(breakParticles, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
        AudioManager.instance.sfxLoopSource1.Stop();
        AudioManager.instance.PlaySfx4("ImpactProyectile");
    }
}