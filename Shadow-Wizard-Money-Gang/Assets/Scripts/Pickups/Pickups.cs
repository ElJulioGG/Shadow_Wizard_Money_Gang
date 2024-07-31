using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int pickupType;
    [SerializeField] private string sound;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.gameObject.tag == "Player")
         {
                pickup(pickupType);
         }   
    }
    private void pickup(int pickupType)
    {
        switch (pickupType)
        {
            case 0:
                GameManager.instance.material1++;
                break;
            case 1:
                GameManager.instance.material2++;
                break;
            case 2:
                GameManager.instance.material3++;
                break;
            case 3:
                GameManager.instance.material4++;
                break;
            case 4:
                if(GameManager.instance.playerHealth < GameManager.instance.playerMaxHealth)
                {
                    GameManager.instance.playerHealth++;
                }
                break;
        }
        AudioManager.instance.PlaySfx(sound);
        pickupDestroy();
    }
    private void pickupDestroy()
    {
        Destroy(gameObject);
    }
}
