using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] public int activeCamera = 0;
    [SerializeField] public int currentPlayerWeapon = 0;
    [SerializeField] public bool playerDied;
    [SerializeField] public bool playerCanInput = true;
    [SerializeField] public bool weaponChange = true;
    [SerializeField] public bool playerIsShadow = false;

    [SerializeField] public int material1 = 0;
    [SerializeField] public int material2 = 0;
    [SerializeField] public int material3 = 0;
    [SerializeField] public int material4 = 0;
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
