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
    private CraftingSystem craftingSystem;

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

        //Item test
        //CreateItem(1, 2, new Item { itemType = Item.ItemType.GhastTear });
        //CreateItem(0, 0, new Item { itemType = Item.ItemType.Crystal });
        //CreateItemOutput(new Item { itemType = Item.ItemType.Sword });
    }

    public void SetCraftingSystem(CraftingSystem craftingSystem)
    {
        this.craftingSystem = craftingSystem;
        craftingSystem.OnGridChanged += CraftingSystem_OnGridChanged;
        UpdateVisual();
    }

    private void CraftingSystem_OnGridChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UI_CraftingSystem_OnItemDropped(object sender, UI_CraftingItemSlot.OnItemDroppedEventArgs e)
    {
        Debug.Log(e.item + " " + e.x + " " + e.y);
        craftingSystem.TryAddItem(e.item, e.x, e.y);
    }

    private void UpdateVisual()
    {
        //Clear old items
        foreach (Transform child in itemContainer)
        {
            Destroy(child.gameObject);
        }

        //Cycle through grid and spawn items
        for (int x = 0; x < CraftingSystem.GRID_SIZE; x++)
        {
            for (int y = 0; y < CraftingSystem.GRID_SIZE; y++)
            {
                if (!craftingSystem.IsEmpty(x, y))
                {
                    CreateItem(x, y, craftingSystem.GetItem(x, y));
                }
            }
        }

        if (craftingSystem.GetOutputItem() != null)
        {
            CreateItemOutput(craftingSystem.GetOutputItem());
        }
    }

    private void CreateItem(int x, int y, Item item)
    {
        Transform itemTransform = Instantiate(pfUI_Item, itemContainer); //Aqui
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
