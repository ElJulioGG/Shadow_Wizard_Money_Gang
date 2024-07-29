using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Player Stats")]
    [SerializeField] public int playerHealth = 3;
    [SerializeField] public int playerDamageReceived = 1;
    [SerializeField] public int playerMaxHealth = 3;
    [SerializeField] public int playerDamage1 = 20;
    [SerializeField] public int playerDamage2 = 10;
    [SerializeField] public int playerBulletForce = 10;
    [Header("Player Conditions")]
    [SerializeField] public bool playerIsHit;
    [SerializeField] public bool playerInvinsibility;
    [SerializeField] public int currentPlayerWeapon = 0;
    [SerializeField] public bool playerDied;
    [SerializeField] public bool playerCanInput = true;
    [SerializeField] public bool playerCanMove = true;
    [SerializeField] public bool weaponChange = true;
    [SerializeField] public bool playerCanAtack = true;
    [SerializeField] public bool playerIsShadow = false;
    [SerializeField] public bool playerIsInDialog = false;
    [SerializeField] public bool playerCanDialog = false;
    [SerializeField] public bool playerCanAlchemy = false;
    [SerializeField] public bool playerPiercingShot = false;


    [SerializeField] public bool defendingBase = false;
    [SerializeField] public bool exploringAndFighting = false;
    [SerializeField] public bool brewingPotions = false;
    [SerializeField] public bool figthingBoss  = false;


    [Header("Camera")]
    [SerializeField] public int activeCamera = 0;

    [Header("Materials")]
    [SerializeField] public int material1 = 0;
    [SerializeField] public int material2 = 0;
    [SerializeField] public int material3 = 0;
    [SerializeField] public int material4 = 0;

    [Header("Bases Conditions")]
    [SerializeField] public int basesDefended = 0;

    [Header("Area Manager")]
    [SerializeField] public bool blockPeCausa = true;
    [SerializeField] public bool blockTower1= true;
    [SerializeField] public bool blockTower2 = true;
    [SerializeField] public bool BlockOutsideBase1A = true;
    [SerializeField] public bool BlockOutsideBase2A = true;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

 
}
