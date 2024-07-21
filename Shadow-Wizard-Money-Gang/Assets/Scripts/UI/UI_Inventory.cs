using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private InventoryManager inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;


    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }

    //public void SetInventory(InventoryManager inventory)
    //{
    //    this.inventory = inventory;

    //    inventory.OnItemListChanged += Inventory_OnItemListChanged;

    //    RefreshInventoryItems();
    //}

    //private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    //{
    //    RefreshInventoryItems();
    //}


    ////private void RefreshInventoryItems() //Inventory stuff
    //{
    //    foreach (Transform child in itemSlotContainer)
    //    {
    //        if (child == itemSlotTemplate) continue;
    //        Destroy(child.gameObject);
    //    }

    //    int x = 0;
    //    int y = 0;
    //    float itemSlotCellSize = 15f;
    //    foreach (Item item in inventory.GetItemList())
    //    {
    //        RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
    //        itemSlotRectTransform.gameObject.SetActive(true);

    //        itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
    //        Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
    //        //image.sprite = item.GetSprite(); //verificar
    //        //Debug.Log(image); //verificar que es "image"
    //        x++;
    //        if (x > 5) //5 items in total so far
    //        {
    //            x = 0;
    //            y++;
    //        }
    //    }
    //}

}