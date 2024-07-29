using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack4 : MonoBehaviour
{
    //public GameObject spawnParticles;
    public GameObject Player;
    public Rigidbody2D playerRb2D;
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    public float recoil;
    public float timer;
    public float timerBetweenFiring;
    [SerializeField] public int ammo = 999;
    private Vector3 newPosition;

    [SerializeField] private float offsetX = 0;
    [SerializeField] private float offsetY = 0;
    [SerializeField] private float offsetZ = 0;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        if (GameManager.instance.playerCanMove)
        {
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

            Vector2 direction = mousePos - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, angle);

            if (!canFire && GameManager.instance.playerCanAtack)
            {
                timer += Time.deltaTime;
                if (timer > timerBetweenFiring)
                {
                    canFire = true;
                    timer = 0;
                }
            }

            if (Input.GetMouseButtonDown(0) && canFire && ammo > 0 && GameManager.instance.playerCanAtack)
            {
                canFire = false;
                Instantiate(bullet, bulletTransform.position, Quaternion.identity);
               
                Vector2 recoilDirection = -direction.normalized;
                playerRb2D.AddForce(recoilDirection * recoil, ForceMode2D.Force);
                Debug.Log("Recoil applied: " + (recoilDirection * 200));

            }
            newPosition = new Vector3(Player.transform.position.x + offsetX, Player.transform.position.y + offsetY, Player.transform.position.z + offsetZ);
            gameObject.transform.position = newPosition;
            if (ammo <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
    private void OnEnable()
    {
        ammo = 999;

        //Instantiate(spawnParticles, Player.transform.position, Quaternion.identity);
        //AudioManager.instance.PlaySfx("TransformEnd");
    }
    private void OnDisable()
    {

        // Instantiate(spawnParticles, Player.transform.position, Quaternion.identity);
        //AudioManager.instance.PlaySfx("TransformEnd");
    }
}
