

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletSpawner : MonoBehaviour
{
    enum SpawnerType { Straight, StraightDuo, Spin }


    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float bulletLife = 1f;
    public float speed = 1f;
    public float RotationSpeed = 1f;

    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate = 1f;


    private GameObject spawnedBullet;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
       
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(spawnerType == SpawnerType.Spin) transform.eulerAngles = new Vector3(0f,0f,transform.eulerAngles.z+RotationSpeed);
        if (timer >= firingRate) {
            Fire();
            timer = 0;
        }
    }


    private void Fire() {

        
        
            if (bullet)
            {
     
                if (spawnerType == SpawnerType.StraightDuo)
                {
                 spawnedBullet = Instantiate(bullet, transform.position, Quaternion.AngleAxis(180, Vector3.forward));
                 spawnedBullet = Instantiate(bullet, transform.position, Quaternion.AngleAxis(0, Vector3.forward));
            }
                else
                {
                 spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                }
                spawnedBullet.GetComponent<Bullet>().speed = speed;
                spawnedBullet.GetComponent<Bullet>().bulletLife = bulletLife;
                spawnedBullet.transform.rotation = transform.rotation;
            }
        

    }
}

