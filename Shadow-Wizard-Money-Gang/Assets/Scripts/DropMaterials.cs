using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMaterials : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float dropQuantity;
    [SerializeField] private GameObject pickup1;
    [SerializeField] private GameObject pickup2;
    [SerializeField] private GameObject pickup3;
    [SerializeField] private GameObject pickup4;
    [SerializeField] private GameObject pickupHeart;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void dropMaterials()
    {

    }
    private void OnDestroy()
    {
        for(int i = 0; i< dropQuantity; i++)
        {
            System.Random random = new System.Random();
            int randomInt = random.Next(0, 4);
            switch(randomInt)
            {
                case 0:
                    Instantiate(pickup1, transform.position, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(pickup2, transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(pickup3, transform.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(pickup4, transform.position, Quaternion.identity);
                    break;
            }
        }
        Instantiate(pickupHeart, transform.position, Quaternion.identity);
    }
}
