using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CraftingSystem : MonoBehaviour
{
    [SerializeField] private Transform pfItemWorld;
    private Transform[,] slotTransformArray;
    private Transform outputSlotTransform;
    private Transform itemContainer;

    private void Awake()
    {
        Transform gridContainer = transform.Find("gridContainer");

        slotTransformArray = new Transform[CraftingSystem.GRID_SIZE, CraftingSystem.GRID_SIZE];

        for (int x = 0; x < CraftingSystem.GRID_SIZE; x++)
        {
            for (int y = 0; y < CraftingSystem.GRID_SIZE; y++)
            {
                slotTransformArray[x, y] = gridContainer.Find("grid_" + x + "_" + y);
            }
        }

        outputSlotTransform = transform.Find("outputSlot");

        //CreateItem(0, 0, new Item { itemType = Item.ItemType.GhastTear });
        //CreateItem(1, 2, new Item { itemType = Item.ItemType.Crystal });
        //CreateItemOutput(new Item { itemType = Item.ItemType.Sword });
    }

    //private void CreateItem(int x, int y, Item item)
    //{
    //    Transform itemTransform = Instantiate(pfItemWorld, itemContainer);
    //    RectTransform itemRectTransform = itemTransform.GetComponent<RectTransform>();
    //    itemRectTransform.anchoredPosition = slotTransformArray[x, y].GetComponent<RectTransform>().anchoredPosition;
    //    itemTransform.GetComponent<UI_Item>().SetItem(item);
    //}
    //
    //private void CreateItemOutput(Item item)
    //{
    //    Transform itemTransform = Instantiate(pfItemWorld, itemContainer);
    //    RectTransform itemRectTransform = itemTransform.GetComponent<RectTransform>();
    //    itemRectTransform.anchoredPosition = outputSlotTransform.GetComponent<RectTransform>().anchoredPosition;
    //    itemTransform.GetComponent<UI_Item>().SetItem(item);
    //}
}
