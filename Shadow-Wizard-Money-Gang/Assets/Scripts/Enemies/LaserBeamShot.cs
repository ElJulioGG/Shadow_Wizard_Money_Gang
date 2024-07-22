using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamShot : MonoBehaviour
{
    public Transform laserFirePoint;
    public LineRenderer linerenderer;
    Transform m_transform;
    private GameObject player;
    public float distanceBullet;
    private float timer = 0f;

    public float TimeBetweenBeam;
    public float lineDuration = 0.5f; // Tiempo que el LineRenderer estará visible
    public float Delay;
    Vector3 Preplayer;

    private void Awake()
    {
        m_transform = GetComponent<Transform>();
        linerenderer.enabled = false;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        timer += Time.deltaTime;
        float distance = Vector2.Distance(transform.position, player.transform.position);


        if (distance <= distanceBullet)
        {
            if (timer >= TimeBetweenBeam)
            {
                Preplayer = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
                Shootlaser();
                timer = 0;
            }
        }
    }

    void Shootlaser()
    {
        if (Physics2D.Raycast(m_transform.position, Preplayer))
        {
            RaycastHit2D _hit = Physics2D.Raycast(laserFirePoint.position, Preplayer);
            StartCoroutine(Draw2DRay(laserFirePoint.position, Preplayer));
        }
        else
        {
            StartCoroutine(Draw2DRay(laserFirePoint.position, Preplayer));
        }
    }
    ////Collision
    //void Shootlaser()
    //{
    //    RaycastHit2D hit = Physics2D.Raycast(laserFirePoint.position, Preplayer - laserFirePoint.position);
    //    if (hit)
    //    {
    //        StartCoroutine(Draw2DRay(laserFirePoint.position, hit.point));
    //        //Lógica para infligir daño al jugador
    //        if (hit.collider.CompareTag("Player"))
    //        {
    //            print("Cock and Balls");
    //        }
    //    }
    //    else
    //    {
    //        StartCoroutine(Draw2DRay(laserFirePoint.position, Preplayer));
    //    }
    //}

    IEnumerator Draw2DRay(Vector2 startPos, Vector2 endPost)
    {
 
        yield return new WaitForSeconds(Delay); 
        linerenderer.SetPosition(0, startPos);
        linerenderer.SetPosition(1, endPost);
        linerenderer.enabled = true;        // Activa el LineRenderer
        yield return new WaitForSeconds(lineDuration); // Espera el tiempo definido
        linerenderer.enabled = false; // Desactiva el LineRenderer
    }
}

