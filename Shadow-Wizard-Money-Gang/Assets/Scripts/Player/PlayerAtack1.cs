using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack1 : MonoBehaviour
{
    //public GameObject spawnParticles;
    public GameObject AtackSprite;
    public Animator AtackAnimator;
    public GameObject Player;
    public GameObject boxCollider2D;
    private Camera mainCam;
    private Vector3 mousePos;
    private Vector3 newPosition;
    //public Transform bulletTransform;
    public bool canFire;
    public float timer; 
    public float timerBetweenFiring;
    [SerializeField] public int ammo = 999;
    [SerializeField] public int resetAmmo = 999;
    private bool colActive = false;
    [SerializeField] private float offsetX = 0;
    [SerializeField] private float offsetY = 0;
    [SerializeField] private float offsetZ = 0;

    [SerializeField] private float spriteAnimTime;
    [SerializeField] private float hitboxDelayTime;
    [SerializeField] private float hitboxDuration;
    void Start()
    {
        AtackSprite.SetActive(false);
        boxCollider2D.SetActive(false);
        mainCam = Camera.main;
    }
    void Update()
    {
        if (GameManager.instance.playerCanMove) {
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

            Vector2 direction = mousePos - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, angle);

            if (!canFire)
            {
                timer += Time.deltaTime;
                if (timer > timerBetweenFiring)
                {
                    canFire = true;
                    timer = 0;
                }
            }

            if (Input.GetMouseButtonDown(0) && canFire && GameManager.instance.playerCanAtack)
            {
                // AtackAnimator.SetTrigger("Swing");
                // AudioManager.instance.PlaySfx("SwordSwing");
                canFire = false;
                AtackSprite.SetActive(true);
                Invoke("activateHitbox", hitboxDelayTime);
                Invoke("deactivateSprite", spriteAnimTime);

                ammo--;
            }

            newPosition = new Vector3(Player.transform.position.x + offsetX, Player.transform.position.y + offsetY, Player.transform.position.z + offsetZ);
            gameObject.transform.position = newPosition;
            if (ammo <= 0)
            {
                //gameObject.SetActive(false);
            }
        }
    }
    private void deactivateHitbox()
    {
        boxCollider2D.SetActive(false);
       
    }
    private void activateHitbox()
    {
        boxCollider2D.SetActive(true);
        Invoke("deactivateHitbox", hitboxDuration);

    }
    private void deactivateSprite()
    {
        AtackSprite.SetActive(false);
    }
    private void OnEnable()
    {
        ammo = resetAmmo;
       // Instantiate(spawnParticles, Player.transform.position, Quaternion.identity);
        //AudioManager.instance.PlaySfx("TransformEnd");
    }
    private void OnDisable()
    {
       // Instantiate(spawnParticles, Player.transform.position, Quaternion.identity);
        //AudioManager.instance.PlaySfx("TransformEnd");
    }
}
