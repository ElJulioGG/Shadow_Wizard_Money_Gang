using System.Collections;
using UnityEngine;

public class Attack3Controller : MonoBehaviour
{
    [SerializeField] private GameObject attackCollider;
    [SerializeField] private float attackDelay = 1f;
    [SerializeField] private float attackDuration = 0.5f;
    private bool canFire = true;

    void Update()
    {
        if (canFire && GameManager.instance.playerCanAtack && Input.GetKeyDown(KeyCode.F))
        {
            canFire = false;
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        Debug.Log("Attack started");
        attackCollider.SetActive(true);
        yield return new WaitForSeconds(attackDuration);
        attackCollider.SetActive(false);
        Debug.Log("Attack finished");

        yield return new WaitForSeconds(attackDelay);
        canFire = true;
        Debug.Log("Ready to attack again");
    }
}