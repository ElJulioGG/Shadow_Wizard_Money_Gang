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
    [SerializeField] private LayerMask wallLayerMask;

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


        if (distance <= distanceBullet && CanSeePlayer(distance))
        {
            if (timer >= TimeBetweenBeam)
            {
                Preplayer = new Vector2(player.transform.position.x, player.transform.position.y);
                Shootlaser();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !GameManager.instance.playerInvinsibility)
        {
            GameManager.instance.playerIsHit = true;

        }
    }

    void Shootlaser()
    {

            StartCoroutine(Draw2DRay(laserFirePoint.position, Preplayer));
    }
    
    IEnumerator Draw2DRay(Vector2 startPos, Vector2 endPost)
    {
 

        yield return new WaitForSeconds(Delay); 
        linerenderer.SetPosition(0, startPos);
        linerenderer.SetPosition(1, endPost);
        linerenderer.enabled = true;        // Activa el LineRenderer
        Vector2 direction = Preplayer - laserFirePoint.position;
        float distance = direction.magnitude;

        // Realiza el Raycast
        RaycastHit2D hit = Physics2D.Raycast(laserFirePoint.position, direction, distance);

        // Dibuja el rayo y verifica si colisionó con el jugador
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            GameManager.instance.playerIsHit = true;
        }
        yield return new WaitForSeconds(lineDuration); // Espera el tiempo definido
        linerenderer.enabled = false; // Desactiva el LineRenderer
    }
}

