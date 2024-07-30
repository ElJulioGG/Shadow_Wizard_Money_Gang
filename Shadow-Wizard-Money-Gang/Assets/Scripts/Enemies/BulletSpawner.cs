using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletSpawner : MonoBehaviour
{
    enum SpawnerType { StraightDuo, StraightQuad, Spin }


    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float bulletLife = 1f;
    public float speed = 1f;

    public float distanceBullet;

    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate = 1f; 
    public float RotationSpeed = 1f;
    [SerializeField] [Range(0, 359)] private float angleSpread1;
    [SerializeField] [Range(0, 359)] private float angleSpread2;
    [SerializeField] [Range(0, 359)] private float angleSpread3;
    [SerializeField] [Range(0, 359)] private float angleSpread4;
    [SerializeField] private LayerMask wallLayerMask;
    private GameObject player;
    private GameObject spawnedBullet;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        timer += Time.deltaTime;
        if(spawnerType == SpawnerType.Spin) transform.eulerAngles = new Vector3(0f,0f,transform.eulerAngles.z+RotationSpeed);
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= distanceBullet && CanSeePlayer(dist))
        {
            if (timer >= firingRate)
            {
                Fire();
                timer = 0;
            }
        }
    }

    private bool CanSeePlayer(float dist)
    {
        Vector2 directionToPlayer = player.transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, dist, wallLayerMask);

        return hit.collider == null;
    }
    private void Fire() {

        
        
            if (bullet)
            {

                if (spawnerType == SpawnerType.StraightDuo)
                {
                    spawnedBullet = Instantiate(bullet, transform.position, Quaternion.AngleAxis(angleSpread1, Vector3.forward));
                  spawnedBullet.GetComponent<Bullet>().speed = speed;
                    spawnedBullet = Instantiate(bullet, transform.position, Quaternion.AngleAxis(angleSpread2, Vector3.forward));
                spawnedBullet.GetComponent<Bullet>().speed = speed;
            }

                if (spawnerType == SpawnerType.Spin)
                {
                    GameObject spawnedBullet = Instantiate(bullet, transform.position, transform.rotation);
                    spawnedBullet.GetComponent<Bullet>().speed = speed;
                    spawnedBullet.GetComponent<Bullet>().bulletLife = bulletLife;
                
    
                    spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                    spawnedBullet.transform.rotation = transform.rotation; 
                }

                if (spawnerType == SpawnerType.StraightQuad)
                {
                    spawnedBullet = Instantiate(bullet, transform.position, Quaternion.AngleAxis(angleSpread1, Vector3.forward));
                    spawnedBullet = Instantiate(bullet, transform.position, Quaternion.AngleAxis(angleSpread2, Vector3.forward));
                    spawnedBullet = Instantiate(bullet, transform.position, Quaternion.AngleAxis(angleSpread3, Vector3.forward));
                    spawnedBullet = Instantiate(bullet, transform.position, Quaternion.AngleAxis(angleSpread4, Vector3.forward));
                }   

                spawnedBullet.GetComponent<Bullet>().speed = speed;
                spawnedBullet.GetComponent<Bullet>().bulletLife = bulletLife;
  
            }
        

    }
}

