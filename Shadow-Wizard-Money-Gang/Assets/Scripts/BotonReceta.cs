using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonReceta : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Item item0, item1, item2, item3;
    [SerializeField] private InventoryManager inventoryManager;

    void OnClick()
    {
        System.Random random = new System.Random();
        int randomInt = random.Next(0, 10);

        //switch (randomInt)
        //{
        //    case 0:
        //        if (inventoryManager.GetItemList)
        //        {
        //            playerController.ConsumeItem(0, 6);
        //        }
        //        break;
        //}

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
