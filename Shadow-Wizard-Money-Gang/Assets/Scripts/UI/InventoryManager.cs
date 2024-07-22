using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager
{
    public event EventHandler OnItemListChanged;
    private List<Item> itemList;

    public InventoryManager()
    {
        itemList = new List<Item>();

        //Current Item list (general)
        //Sword,
        //GhastTear,
        //SpiderEye,
        //Crystal,
        //ShadowHorn,

        AddItem(new Item { itemType = Item.ItemType.Sword, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.GhastTear, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.SpiderEye, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Crystal, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.ShadowHorn, amount = 1 });

        //Testing
        //Debug.Log(itemList.Count);
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

}
