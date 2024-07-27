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
        timer += Time.deltaTime;
        if(spawnerType == SpawnerType.Spin) transform.eulerAngles = new Vector3(0f,0f,transform.eulerAngles.z+RotationSpeed);
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= distanceBullet)
        {
            if (timer >= firingRate)
            {
                Fire();
                timer = 0;
            }
        }
    }


    private void Fire() {

        
        
            if (bullet)
            {
     
                if (spawnerType == SpawnerType.StraightDuo)
                {
                 spawnedBullet = Instantiate(bullet, transform.position, Quaternion.AngleAxis(angleSpread1, Vector3.forward));
                 spawnedBullet = Instantiate(bullet, transform.position, Quaternion.AngleAxis(angleSpread2, Vector3.forward));
                }

                if(spawnerType == SpawnerType.Spin)
                {
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

