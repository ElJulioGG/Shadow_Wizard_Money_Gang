using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class InventoryManager
{
    public event EventHandler OnItemListChanged;
    
    private List<Item> itemList;

    private Action<Item> useItemAction;

    public InventoryManager(Action<Item> useItemAction)
    {
        this.useItemAction = useItemAction;
        itemList = new List<Item>();

        //Current Item list (general)
        //Sword,
        //GhastTear,
        //SpiderEye,
        //Crystal,
        //ShadowHorn,

        //Iniciar con 5 items (Sword, GhastTear, SpiderEye, Crystal, ShadowHorn)
        //AddItem(new Item { itemType = Item.ItemType.Sword, amount = 1 });
        //AddItem(new Item { itemType = Item.ItemType.GhastTear, amount = 1 });
        //AddItem(new Item { itemType = Item.ItemType.SpiderEye, amount = 1 });
        //AddItem(new Item { itemType = Item.ItemType.Crystal, amount = 1 });
        //AddItem(new Item { itemType = Item.ItemType.ShadowHorn, amount = 1 });

        //Testing
        //Debug.Log(itemList.Count);
    }

    //public void AddItem(Item item)
    //{
    //    if (item.IsStackable()) //Error con el pfItemWorld/ItemWorld al activar
    //    {
    //        //Debug.Log("pfItemWorld");
    //        bool itemAlreadyInInventory = false;
    //        foreach (Item inventoryItem in itemList)
    //        {
    //            if (inventoryItem.itemType == item.itemType)
    //            {
    //                inventoryItem.amount += item.amount;
    //                itemAlreadyInInventory = true;
    //            }
    //        }
    //        if (!itemAlreadyInInventory)
    //        {
    //            itemList.Add(item);
    //        }
    //    }
    //    else
    //    {
    //        itemList.Add(item);
    //    }
    //    OnItemListChanged?.Invoke(this, EventArgs.Empty);
    //}

    public void RemoveItem(Item item)
    {
        if (item.IsStackable())
        {
            Item itemInInventory = null;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount -= item.amount;
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null && itemInInventory.amount <= 0)
            {
                itemList.Remove(itemInInventory);
            }
        }
        else
        {
            itemList.Remove(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void UseItem(Item item)
    {
        useItemAction(item);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

}
