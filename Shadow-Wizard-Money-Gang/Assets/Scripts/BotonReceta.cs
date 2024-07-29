using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonReceta : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Item item0, item1, item2, item3;
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private UI_Inventory ui_inventory;

    void OnClick()
    {
        System.Random random = new System.Random();
        int randomInt = random.Next(0, 10);
        playerController.UseItem(inventoryManager.itemList[0]);
        playerController.ConsumeItem(inventoryManager.itemList[0], 2);
        playerController.ConsumeItem(inventoryManager.itemList[1], 2);
        playerController.ConsumeItem(inventoryManager.itemList[2], 2);
        playerController.ConsumeItem(inventoryManager.itemList[3], 2);
        switch (randomInt)
        {

            case 0:
                if (playerController.getGhastItemQuantity() >=6)
                {
                    playerController.ConsumeItem(item0, 6);
               
                    
                }
                else
                {
                    OnClick();
                }
                break;
            case 1:
                if (playerController.getGhastItemQuantity() >= 2 && playerController.getSpiderEyeQuantity() >= 2 && playerController.getCrystalQuantity() >= 2 && playerController.getShadowHornQuantity() >= 2)
                {
                    playerController.ConsumeItem(inventoryManager.itemList[0], 2);
                    playerController.ConsumeItem(inventoryManager.itemList[1], 2);
                    playerController.ConsumeItem(inventoryManager.itemList[2], 2);
                    playerController.ConsumeItem(inventoryManager.itemList[3], 2);
                }
                else
                {
                    OnClick();
                }
                break;
            case 2:
                if (playerController.getGhastItemQuantity() >= 1 && playerController.getSpiderEyeQuantity() >= 1 && playerController.getCrystalQuantity() >= 3 && playerController.getShadowHornQuantity() >= 3)
                {
                    playerController.ConsumeItem(inventoryManager.itemList[0], 1);
                    playerController.ConsumeItem(inventoryManager.itemList[1], 1);
                    playerController.ConsumeItem(inventoryManager.itemList[2], 3);
                    playerController.ConsumeItem(inventoryManager.itemList[3], 3);
                }
                else
                {
                    OnClick();
                }
                break;

            case 3:
                if ( playerController.getCrystalQuantity() >= 4 && playerController.getShadowHornQuantity() >= 4)
                {
                
                    playerController.ConsumeItem(inventoryManager.itemList[2], 4);
                    playerController.ConsumeItem(inventoryManager.itemList[3], 3);
                }
                else
                {
                    OnClick();
                }
                break;
            case 4:
                if (playerController.getGhastItemQuantity() >= 2 && playerController.getShadowHornQuantity() >= 5)
                {
                    playerController.ConsumeItem(inventoryManager.itemList[0], 2);
                    playerController.ConsumeItem(inventoryManager.itemList[3], 5);
                }
                else
                {
                    OnClick();
                }
                break;
            case 5:
                if (playerController.getGhastItemQuantity() >= 2 && playerController.getSpiderEyeQuantity() >= 2 && playerController.getShadowHornQuantity() >= 4)
                {
                    playerController.ConsumeItem(inventoryManager.itemList[0], 2);
                    playerController.ConsumeItem(inventoryManager.itemList[1], 2);
                    playerController.ConsumeItem(inventoryManager.itemList[3], 4);
                }
                else
                {
                    OnClick();
                }
                break;
            case 6:
                if (playerController.getGhastItemQuantity() >= 7 && playerController.getShadowHornQuantity() >= 1)
                {
                    playerController.ConsumeItem(inventoryManager.itemList[0], 7);
                    
                    playerController.ConsumeItem(inventoryManager.itemList[3], 1);
                }
                else
                {
                    OnClick();
                }
                break;
            case 7:
                if ( playerController.getSpiderEyeQuantity() >= 3 && playerController.getCrystalQuantity() >= 3)
                {
                   
                    playerController.ConsumeItem(inventoryManager.itemList[1], 3);
                    playerController.ConsumeItem(inventoryManager.itemList[2], 3);
                   
                }
                else
                {
                    OnClick();
                }
                break;
            case 8:
                if (playerController.getGhastItemQuantity() >= 4 && playerController.getSpiderEyeQuantity() >= 4 && playerController.getCrystalQuantity() >= 4 && playerController.getShadowHornQuantity() >= 4)
                {
                    playerController.ConsumeItem(inventoryManager.itemList[0], 4);
                    playerController.ConsumeItem(inventoryManager.itemList[1], 4);
                    playerController.ConsumeItem(inventoryManager.itemList[2], 4);
                    playerController.ConsumeItem(inventoryManager.itemList[3], 4);
                }
                else
                {
                    OnClick();
                }
                break;
            case 9:
                if (playerController.getGhastItemQuantity() >= 4 && playerController.getSpiderEyeQuantity() >= 1 && playerController.getCrystalQuantity() >= 4 && playerController.getShadowHornQuantity() >= 2)
                {
                    playerController.ConsumeItem(inventoryManager.itemList[0], 4);
                    playerController.ConsumeItem(inventoryManager.itemList[1], 1);
                    playerController.ConsumeItem(inventoryManager.itemList[2], 4);
                    playerController.ConsumeItem(inventoryManager.itemList[3], 2);
                }
                else
                {
                    OnClick();
                }
                break;

        }
        ui_inventory.RefreshInventoryItems();
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
