using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameObject bulletPrefab;
    //[SerializeField] private int burstCount;
    //[SerializeField] private int projectilesPerBurst;
    //[SerializeField] [Range(0, 359)] private float angleSpread;
    //[SerializeField] private float startingDistance = 0.1f;
    //[SerializeField] private float timeBetweenBursts;
   // [SerializeField] private float restTime = 1f;
   // [SerializeField] private bool stagger;
    //[SerializeField] private bool oscillate;
   // [SerializeField] private bool Boss;
    private float EnemyHealth;
    private EnemyDamage ED;

    private float timer = 0f;
    private bool isShooting = false;
    public float distanceBullet;
    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        ED = GetComponent<EnemyDamage>();

    }
    private void Update()
    {
        //EnemyHealth = ED.enemyHealth;
        //timer += Time.deltaTime;
        //print(EnemyHealth);
        //float distance = Vector2.Distance(transform.position, player.transform.position);
        //if (distance <= distanceBullet)
        //{
        //    timer += Time.deltaTime;
        //    if (timer >= timeBetweenBursts)
        //    {
        //        Attack();
        //        timer = 0;
        //    }
        //}

    }
    
    public void AttackBoss1()
    {
        if (!isShooting)
        {   //                              float timeBetweenBursts, int projectilesPerBurst, float restTime,   int burstCount, bool stagger, bool oscillate, float angleSpread , float startingDistance
            StartCoroutine(ShootRoutineBoss( 1f, 1, 0.2f, 1,  false ,false, 10f, 0.1f));
        }
    }

    private IEnumerator ShootRoutineBoss(float timeBetweenBursts, int projectilesPerBurst, float restTime,   int burstCount, bool stagger, bool oscillate, float angleSpread , float startingDistance)
    {

        isShooting = true;


        float timeBetweenProjectiles = 0f;
        float startAngle, currentAngle, angleStep, endAngle;
        TargetConeOfInfluence(out startAngle, out currentAngle, out angleStep, out endAngle, angleSpread, projectilesPerBurst);

        if (stagger) { timeBetweenProjectiles = timeBetweenBursts / projectilesPerBurst; }

        for (int i = 0; i < burstCount; i++)
        {
            if (!oscillate)
            {
                TargetConeOfInfluence(out startAngle, out currentAngle, out angleStep, out endAngle, angleSpread, projectilesPerBurst);
            }
            if (oscillate && i % 2 != 1)
            {
                TargetConeOfInfluence(out startAngle, out currentAngle, out angleStep, out endAngle, angleSpread, projectilesPerBurst);
            }
            else if (oscillate)
            {
                currentAngle = endAngle;
                endAngle = startAngle;
                startAngle = currentAngle;
                angleStep *= -1;
            }

            for (int j = 0; j < projectilesPerBurst; j++)
            {
                Vector2 pos = FindBulletSpawnPos(currentAngle, startingDistance);

                GameObject newBullet = Instantiate(bulletPrefab, pos, Quaternion.identity);
                newBullet.transform.right = newBullet.transform.position - transform.position;

                currentAngle += angleStep;

                if (stagger) { yield return new WaitForSeconds(timeBetweenProjectiles); }
            }

            currentAngle = startAngle;

            if (!stagger) { yield return new WaitForSeconds(timeBetweenBursts); }
        }
        yield return new WaitForSeconds(restTime);
        isShooting = false;
    }

    private void TargetConeOfInfluence(out float startAngle, out float currentAngle, out float angleStep, out float endAngle, float angleSpread, int projectilesPerBurst )
    {
        Vector2 targetDirection = player.transform.position - transform.position;
        float targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        startAngle = targetAngle;
        endAngle = targetAngle;
        currentAngle = targetAngle;
        float halfAngleSpread = 0f;
        angleStep = 0f;
        if (angleSpread != 0)
        {
            angleStep = angleSpread / (projectilesPerBurst);
            halfAngleSpread = angleSpread / 2f;
            startAngle = targetAngle - halfAngleSpread;
            endAngle = targetAngle + halfAngleSpread;
            currentAngle = startAngle;
        }
    }

    private Vector2 FindBulletSpawnPos(float currentAngle, float startingDistance)
    {
        float x = transform.position.x + startingDistance * Mathf.Cos(currentAngle * Mathf.Deg2Rad);
        float y = transform.position.y + startingDistance * Mathf.Sin(currentAngle * Mathf.Deg2Rad);

        Vector2 pos = new Vector2(x, y);

        return pos;
    }

}
