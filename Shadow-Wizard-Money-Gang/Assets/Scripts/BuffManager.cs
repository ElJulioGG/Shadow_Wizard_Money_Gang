using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    [SerializeField] private PlayerAtack2 playerAtack2;
    [SerializeField] private PlayerAtack4 playerAtack4;
    [SerializeField] private GameObject Atack1;
    [SerializeField] private GameObject Atack4;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private HealthBar healthBar;
    public void Buff1()
    {
        GameManager.instance.playerDamage2 = GameManager.instance.playerDamage2/2;
        playerAtack2.timerBetweenFiring = playerAtack2.timerBetweenFiring / 6;
        playerAtack4.timerBetweenFiring = playerAtack4.timerBetweenFiring / 6;
    }
    public void Buff2()
    {
        GameManager.instance.playerHealth = GameManager.instance.playerHealth + 4;
        GameManager.instance.playerMaxHealth = GameManager.instance.playerMaxHealth+ 4;
        playerController.activeMoveSpeed = playerController.activeMoveSpeed / 1.5f;
        playerController.dashMoveSpeed = playerController.dashMoveSpeed/1.5f;
        healthBar.drawHearts();
    }
    public void Buff3()
    {
        GameManager.instance.playerDamageReceived = GameManager.instance.playerDamageReceived + 1;
        playerAtack2.timerBetweenFiring = playerAtack2.timerBetweenFiring / 1.5f;
        playerAtack4.timerBetweenFiring = playerAtack4.timerBetweenFiring / 1.5f;
        Atack1.SetActive(false);
        Atack4.SetActive(true);

    }
    public void Buff4()
    {
        GameManager.instance.playerPiercingShot = true;
        GameManager.instance.playerBulletForce = GameManager.instance.playerBulletForce / 2;
        GameManager.instance.playerDamage2 = GameManager.instance.playerDamage2 -1;

    }
}
