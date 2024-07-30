using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    [SerializeField] private PlayerAtack2 playerAtack2;
    [SerializeField] private Attack3Controller atack3Controller;
    [SerializeField] private PlayerAtack4 playerAtack4;
    [SerializeField] private GameObject Atack1;
    [SerializeField] private GameObject Atack1Sprite;
    [SerializeField] private GameObject Atack4;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private GameObject playerProyectileCollider;
    public void Buff1()//"Soy potion: More bullets, less damage";
    {
        GameManager.instance.playerDamage2 = GameManager.instance.playerDamage2 / 2;
        playerAtack2.timerBetweenFiring = playerAtack2.timerBetweenFiring / 6;
        playerAtack4.timerBetweenFiring = playerAtack4.timerBetweenFiring / 6;
    }
    public void Buff2()//GainsMaxxer Potion: Chunky body, bad mobility";
    {
        GameManager.instance.playerHealth = GameManager.instance.playerHealth + 4;
        GameManager.instance.playerMaxHealth = GameManager.instance.playerMaxHealth + 4;
        playerController.activeMoveSpeed = playerController.activeMoveSpeed / 1.5f;
        playerController.dashMoveSpeed = playerController.dashMoveSpeed / 1.5f;
        healthBar.drawHearts();
    }
    public void Buff3()//: Double Projectiles!";
    {
        GameManager.instance.playerSyncAtack = true;
        GameManager.instance.playerDamageReceived = GameManager.instance.playerDamageReceived + 1;
        playerAtack2.timerBetweenFiring = playerAtack2.timerBetweenFiring / 1.2f;
        playerAtack4.timerBetweenFiring = playerAtack4.timerBetweenFiring / 1.2f;
        Atack1.SetActive(false);
        Atack4.SetActive(true);

    }
    public void Buff4()//": PiercingShot + dmg a bit down";
    {
        GameManager.instance.playerPiercingShot = true;
        GameManager.instance.playerBulletForce = GameManager.instance.playerBulletForce / 2;
        GameManager.instance.playerDamage2 = GameManager.instance.playerDamage2 - 1;

    }
    public void Buff5()//"Beeg flufin blast: B";
    {
        Atack1.SetActive(true);
        Atack4.SetActive(false);
        Atack1Sprite.transform.localScale = new Vector3(Atack1Sprite.transform.localScale.x + 0.5f, Atack1Sprite.transform.localScale.y + 0.5f, Atack1Sprite.transform.localScale.z + 0.5f);
        GameManager.instance.playerDamage1 = GameManager.instance.playerDamage1 + 5;
        GameManager.instance.playerDamage2 = GameManager.instance.playerDamage2/2;

    }
    public void Buff6()//"I am speed - damage";
    {
        playerController.activeMoveSpeed = playerController.activeMoveSpeed * 1.5f;
        playerController.dashMoveSpeed = playerController.dashMoveSpeed * 1.5f;
        GameManager.instance.playerDamage1 = GameManager.instance.playerDamage1 - 5;
        GameManager.instance.playerDamage2 = GameManager.instance.playerDamage2 / 1.5f;
    }
    public void Buff7()//"synced attacks, faster atack, less damage"
    {
        GameManager.instance.playerDamage1 = GameManager.instance.playerDamage1 - 3;
        GameManager.instance.playerDamage2 = GameManager.instance.playerDamage2 - 2;
        GameManager.instance.playerSyncAtack = true;
        playerAtack2.timerBetweenFiring = playerAtack2.timerBetweenFiring -0.2f;
        playerAtack4.timerBetweenFiring = playerAtack4.timerBetweenFiring -0.2f;
    }
    public void Buff8()
    {
        atack3Controller.attackDuration = atack3Controller.attackDuration * 2;
        GameManager.instance.playerHealth = GameManager.instance.playerHealth -1;
        GameManager.instance.playerMaxHealth = GameManager.instance.playerMaxHealth -1;
        healthBar.drawHearts();
    }
    public void Buff9()
    {
        playerController.dashMoveSpeed = playerController.dashMoveSpeed + 0.5f;
        playerController.activeMoveSpeed = playerController.activeMoveSpeed + 0.5f;
        GameManager.instance.playerDamage1 = GameManager.instance.playerDamage1 +4;
        GameManager.instance.playerDamage2 = GameManager.instance.playerDamage2 +2;
        playerAtack2.timerBetweenFiring = playerAtack2.timerBetweenFiring - 0.2f;
        playerAtack4.timerBetweenFiring = playerAtack4.timerBetweenFiring - 0.2f;
        atack3Controller.attackDuration = atack3Controller.attackDuration +0.5f;
        GameManager.instance.playerHealth = GameManager.instance.playerHealth +1;
        GameManager.instance.playerMaxHealth = GameManager.instance.playerMaxHealth +1;
        healthBar.drawHearts();
    }
    public void Buff10()
    {
        playerProyectileCollider.transform.localScale = new Vector3(playerProyectileCollider.transform.localScale.x/2f, playerProyectileCollider.transform.localScale.y/2f, playerProyectileCollider.transform.localScale.z/2f);
        playerController.dashMoveSpeed = playerController.dashMoveSpeed / 2.5f;
    }
}