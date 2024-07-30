using System.Collections;
using System.Reflection;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Attack3Controller : MonoBehaviour
{
    [SerializeField] private GameObject attackCollider;
    [SerializeField] private float attackDelay = 1f;
    [SerializeField] public float attackDuration = 0.5f;
    private bool canFire = true;
    public GameObject breakParticles;
    public Slider shieldCooldownBar; //Shield cooldown stuff
    private float timer = 0f;
    private bool inCooldown= false;

    void Update()
    {
        if (canFire && GameManager.instance.playerCanAtack && Input.GetKeyDown(KeyCode.F))
        {
            canFire = false;
            StartCoroutine(Attack());
        }


        //Shield cooldown
        //shieldCooldownBar.maxValue = 1f;
        //shieldCooldownBar.minValue = 0f;
        if (inCooldown && timer <= attackDelay) {
            
            shieldCooldownBar.value = timer;
            
            timer += Time.deltaTime ;
        }
        else
        {
            timer=0 ;
           
        }

    }

    IEnumerator Attack()
    {
        
        Debug.Log("Attack started");
        AudioManager.instance.PlaySfx2("Shield");
        attackCollider.SetActive(true);
        yield return new WaitForSeconds(attackDuration);
        attackCollider.SetActive(false);
        inCooldown = true;
        Debug.Log("Attack finished");
        Instantiate(breakParticles, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(attackDelay);
        inCooldown = false;
        canFire = true;
        Debug.Log("Ready to attack again");

    }
}