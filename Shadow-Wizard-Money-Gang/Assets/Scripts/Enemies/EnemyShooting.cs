using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    enum ShootType { Single, QuadShot, OctaShot }
    //enum SpawnerType { Straight, Spin }

    [Header("Bullet Attributes")]
    public GameObject bullet;
    public Transform bulletPos;
    public float distanceBullet;

    private float timer = 0f;
    private GameObject player;
    

    //public float RotationSpeed = 1f;

    [Header("Type")]
    [SerializeField] private ShootType shootType;
    [SerializeField] private float firingRate = 1f;
    //[SerializeField] private SpawnerType spawnerType;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        float distance = Vector2.Distance(transform.position, player.transform.position);
        //if (spawnerType == SpawnerType.Spin) transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + RotationSpeed);
        if (distance <=distanceBullet)
        {
            timer += Time.deltaTime;

            if (timer >= firingRate)
            {
                timer = 0;
                shoot();
            }
        }
    }

    void shoot()
    {
        if(shootType == ShootType.Single)
        {
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
        }

        if (shootType == ShootType.QuadShot)
        {
            Instantiate(bullet, bulletPos.position, Quaternion.AngleAxis(0, Vector3.forward));
            Instantiate(bullet, bulletPos.position, Quaternion.AngleAxis(90, Vector3.forward));
            Instantiate(bullet, bulletPos.position, Quaternion.AngleAxis(180, Vector3.forward));
            Instantiate(bullet, bulletPos.position, Quaternion.AngleAxis(270, Vector3.forward));
        }

        if (shootType == ShootType.OctaShot)
        {
            
                Instantiate(bullet, bulletPos.position, Quaternion.AngleAxis(0, Vector3.forward));
                Instantiate(bullet, bulletPos.position, Quaternion.AngleAxis(45, Vector3.forward));
                Instantiate(bullet, bulletPos.position, Quaternion.AngleAxis(90, Vector3.forward));
                Instantiate(bullet, bulletPos.position, Quaternion.AngleAxis(135, Vector3.forward));
                Instantiate(bullet, bulletPos.position, Quaternion.AngleAxis(180, Vector3.forward));
                Instantiate(bullet, bulletPos.position, Quaternion.AngleAxis(225, Vector3.forward));
                Instantiate(bullet, bulletPos.position, Quaternion.AngleAxis(270, Vector3.forward));
                Instantiate(bullet, bulletPos.position, Quaternion.AngleAxis(315, Vector3.forward));

        }
    }


}
