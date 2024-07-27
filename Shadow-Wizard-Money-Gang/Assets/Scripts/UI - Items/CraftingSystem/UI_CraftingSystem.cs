using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;

public class UI_CraftingSystem : MonoBehaviour
{
    [SerializeField] private Transform pfUI_Item;
    private Transform[,] slotTransformArray;
    private Transform outputSlotTransform;
    private Transform itemContainer;

    private void Awake()
    {
        Transform gridContainer = transform.Find("gridContainer");
        itemContainer = transform.Find("itemContainer");

        slotTransformArray = new Transform[CraftingSystem.GRID_SIZE, CraftingSystem.GRID_SIZE];

        for (int x = 0; x < CraftingSystem.GRID_SIZE; x++)
        {
            for (int y = 0; y < CraftingSystem.GRID_SIZE; y++)
            {
                slotTransformArray[x, y] = gridContainer.Find("grid_" + x + "_" + y);
                //slotTransformArray[x, y].GetComponent<UI_CraftingItemSlot>().OnItemDropped += UI_CraftingSystem_OnItemDropped;
                UI_CraftingItemSlot craftingItemSlot = slotTransformArray[x, y].GetComponent<UI_CraftingItemSlot>(); //Aqui
                craftingItemSlot.SetXY(x, y);
                craftingItemSlot.OnItemDropped += UI_CraftingSystem_OnItemDropped;
            }
        }

        outputSlotTransform = transform.Find("outputSlot");

        CreateItem(0, 0, new Item { itemType = Item.ItemType.GhastTear });
        CreateItem(1, 2, new Item { itemType = Item.ItemType.Crystal });
        CreateItemOutput(new Item { itemType = Item.ItemType.Sword });
    }

    private void UI_CraftingSystem_OnItemDropped(object sender, UI_CraftingItemSlot.OnItemDroppedEventArgs e)
    {
        Debug.Log(e.item + " " + e.x + " " + e.y);
        //Debug.Log("This is a spot");
    }

    private void CreateItem(int x, int y, Item item)
    {
        Transform itemTransform = Instantiate(pfUI_Item, itemContainer);
        RectTransform itemRectTransform = itemTransform.GetComponent<RectTransform>();
        itemRectTransform.anchoredPosition = slotTransformArray[x, y].GetComponent<RectTransform>().anchoredPosition;
        itemTransform.GetComponent<UI_Item>().SetItem(item);
    }
    
    private void CreateItemOutput(Item item)
    {
        Transform itemTransform = Instantiate(pfUI_Item, itemContainer);
        RectTransform itemRectTransform = itemTransform.GetComponent<RectTransform>();
        itemRectTransform.anchoredPosition = outputSlotTransform.GetComponent<RectTransform>().anchoredPosition;
        itemTransform.GetComponent<UI_Item>().SetItem(item);
    }
}
