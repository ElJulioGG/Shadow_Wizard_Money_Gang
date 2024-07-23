using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Player Stats")]
    [SerializeField] public int playerHealth = 3;
    [SerializeField] public int playerMaxHealth = 3;
    [SerializeField] public int playerDamage1 = 20;
    [SerializeField] public int playerDamage2 = 10;
    [Header("Player Conditions")]
    [SerializeField] public bool playerIsHit;
    [SerializeField] public bool playerInvinsibility;
    [SerializeField] public int currentPlayerWeapon = 0;
    [SerializeField] public bool playerDied;
    [SerializeField] public bool playerCanInput = true;
    [SerializeField] public bool weaponChange = true;
    [SerializeField] public bool playerIsShadow = false;

    [Header("Camera")]
    [SerializeField] public int activeCamera = 0;

    [Header("Materials")]
    [SerializeField] public int material1 = 0;
    [SerializeField] public int material2 = 0;
    [SerializeField] public int material3 = 0;
    [SerializeField] public int material4 = 0;

    [Header("Bases Conditions")]
    [SerializeField] public int basesDefended = 0;


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
