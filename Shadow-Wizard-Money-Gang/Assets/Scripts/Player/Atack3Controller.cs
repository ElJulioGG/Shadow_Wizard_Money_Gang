using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Attack3Controller : MonoBehaviour
{
    [SerializeField] private GameObject attackCollider;
    [SerializeField] private float attackDelay = 1f;
    [SerializeField] private float attackDuration = 0.5f;
    private bool canFire = true;
    public GameObject breakParticles;
    public Slider shieldCooldownBar; //Shield cooldown stuff

    void Update()
    {
        if (canFire && GameManager.instance.playerCanAtack && Input.GetKeyDown(KeyCode.F))
        {
            canFire = false;
            StartCoroutine(Attack());
        }
        //d
        //Shield cooldown
        //shieldCooldownBar.maxValue = 1f;
        //shieldCooldownBar.minValue = 0f;
        shieldCooldownBar.value = attackDelay / attackDuration;
        if (shieldCooldownBar.value >= 1f)
        {
            shieldCooldownBar.gameObject.SetActive(false);
        }
        else
        {
            shieldCooldownBar.gameObject.SetActive(true);
        }

    }

    IEnumerator Attack()
    {
        Debug.Log("Attack started");
        AudioManager.instance.PlaySfx2("Shield");
        attackCollider.SetActive(true);
        yield return new WaitForSeconds(attackDuration);
        attackCollider.SetActive(false);
        Debug.Log("Attack finished");
        Instantiate(breakParticles, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(attackDelay);
        canFire = true;
        Debug.Log("Ready to attack again");

    }
}