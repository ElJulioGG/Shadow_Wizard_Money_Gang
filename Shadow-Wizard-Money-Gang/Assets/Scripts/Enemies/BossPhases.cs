using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhases : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    private GameObject player;
    [SerializeField] private GameObject bulletPrefab;
    private int burstCount;
    private int projectilesPerBurst;
    /*[Range(0, 359)]*/
    private float angleSpread;
    [SerializeField] private float startingDistance = 0.1f;
    private float timeBetweenBursts;
    private float restTime = 1f;
    private bool stagger;
    private bool oscillate;
    private float TotalEnemyHealth;
    private float EnemyHealth;
    private EnemyDamage ED;
    public Animator animatorBoss;
    private bool canShoot = true;
    private float timer = 0f;
    private bool isShooting = false;

    private void Start()
    {


        player = GameObject.FindGameObjectWithTag("Player");
        ED = GetComponent<EnemyDamage>();
        EnemyHealth = ED.enemyHealth;
        TotalEnemyHealth = EnemyHealth;
    }


    private void Update()
    {
        if (canShoot)
        {
            EnemyHealth = ED.enemyHealth;
            timer += Time.deltaTime;

            if (EnemyHealth >= TotalEnemyHealth - (0.20 * TotalEnemyHealth))
            {
                animatorBoss.SetTrigger("Fase1");
                //Parametros Fase 1 
                burstCount = 1;
                projectilesPerBurst = 1;
                angleSpread = 0;
                startingDistance = 0.1f;
                timeBetweenBursts = 0;
                restTime = 0.2f;
                stagger = false;
                oscillate = false;
                if (timer >= restTime)
                {
                    Attack();
                    timer = 0;
                }

            }
            else
                if (EnemyHealth >= TotalEnemyHealth - (0.40 * TotalEnemyHealth))
            {
                animatorBoss.SetTrigger("Fase2");
                burstCount = 3;
                projectilesPerBurst = 8;
                angleSpread = 120;
                startingDistance = 0.1f;
                timeBetweenBursts = 0.8f;
                restTime = 1f;
                stagger = true;
                oscillate = true;

                if (timer >= restTime)
                {
                    Attack();
                    timer = 0;
                }
            }
            else
                if (EnemyHealth >= TotalEnemyHealth - (0.60 * TotalEnemyHealth))
            {
                animatorBoss.SetTrigger("Fase3");
                burstCount = 2;
                projectilesPerBurst = 5;
                angleSpread = 90;
                startingDistance = 0.1f;
                timeBetweenBursts = 0.5f;
                restTime = 0.3f;
                stagger = false;
                oscillate = false;

                if (timer >= restTime)
                {
                    Attack();
                    timer = 0;
                }
                print("FASE 3 :V");
            }
            else
                if (EnemyHealth >= TotalEnemyHealth - (0.80 * TotalEnemyHealth))
            {
                animatorBoss.SetTrigger("Fase4");
                burstCount = 2;
                projectilesPerBurst = 30;
                angleSpread = 180;
                startingDistance = 0.1f;
                timeBetweenBursts = 0.4f;
                restTime = 0.2f;
                stagger = false;
                oscillate = false;

                if (timer >= restTime)
                {
                    Attack();
                    timer = 0;
                }
                print("FASE 4 :V");
            }
            else
            if (EnemyHealth > 0)
            {
                animatorBoss.SetTrigger("Fase5");
                burstCount = 3;
                projectilesPerBurst = 18;
                angleSpread = 359;
                startingDistance = 0.1f;
                timeBetweenBursts = 0.5f;
                restTime = 0.2f;
                stagger = false;
                oscillate = false;

                if (timer >= restTime)
                {
                    Attack();
                    timer = 0;
                }
                print("FASE 5 :V");
            }
            if (EnemyHealth<= 0)
            {
                GameManager.instance.playerCanInput = false;
                GameManager.instance.playerCanMove = false;
                GameManager.instance.playerInvinsibility= true;
                gameOver.SetActive(true);

            }
        }

    }

    private void EnableShoot()
    {
        canShoot = true;
    }

    private void DisableShoot()
    {
        canShoot = false;
    }

    public void Attack()
    {
        if (!isShooting)
        {
            StartCoroutine(ShootRoutine());
        }
    }

    private IEnumerator ShootRoutine()
    {

        isShooting = true;


        float timeBetweenProjectiles = 0f;
        float startAngle, currentAngle, angleStep, endAngle;
        TargetConeOfInfluence(out startAngle, out currentAngle, out angleStep, out endAngle);

        if (stagger) { timeBetweenProjectiles = timeBetweenBursts / projectilesPerBurst; }

        for (int i = 0; i < burstCount; i++)
        {
            if (!oscillate)
            {
                TargetConeOfInfluence(out startAngle, out currentAngle, out angleStep, out endAngle);
            }
            if (oscillate && i % 2 != 1)
            {
                TargetConeOfInfluence(out startAngle, out currentAngle, out angleStep, out endAngle);
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
                Vector2 pos = FindBulletSpawnPos(currentAngle);

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

    private void TargetConeOfInfluence(out float startAngle, out float currentAngle, out float angleStep, out float endAngle)
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

    private Vector2 FindBulletSpawnPos(float currentAngle)
    {
        float x = transform.position.x + startingDistance * Mathf.Cos(currentAngle * Mathf.Deg2Rad);
        float y = transform.position.y + startingDistance * Mathf.Sin(currentAngle * Mathf.Deg2Rad);

        Vector2 pos = new Vector2(x, y);

        return pos;
    }

    

}
