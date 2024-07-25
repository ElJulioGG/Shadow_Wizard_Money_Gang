using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
//using TMPro;
//using CodeMonkey.Utils;

public class UI_CraftingSystem : MonoBehaviour
{
    [SerializeField] private Transform pfItemWorld;
    private Transform[,] slotTransformArray;
    private Transform outputSlotTransform;
    private Transform itemContainer;
    //Crafting Inventory stuff
    //private InventoryManager inventory;
    //private Transform craftingItemSlotContainer;
    //private Transform craftingItemSlotTemplate;
    //private PlayerController player;

    private void Awake()
    {
        //Crafting Inventory stuff
        //craftingItemSlotContainer = transform.Find("craftingItemSlotContainer");
        //craftingItemSlotTemplate = craftingItemSlotContainer.Find("craftingItemSlotTemplate");

        //public void SetInventory(InventoryManager inventory)
        //{
        //    this.inventory = inventory;
        //
        //    inventory.OnItemListChanged += Inventory_OnItemListChanged;
        //
        //    RefreshInventoryItems();
        //
        //}

        //void Inventory_OnCraftingItemListChanged(object sender, System.EventArgs e)
        //{
        //    RefreshCraftingInventoryItems();
        //}
        //
        //
        // void RefreshCraftingInventoryItems() //Crafting Inventory stuff
        //{
        //    foreach (Transform child in craftingItemSlotContainer)
        //    {
        //        if (child == craftingItemSlotTemplate) continue;
        //        Destroy(child.gameObject);
        //    }
        //
        //    int xC = 0;
        //    int yC = -2;
        //    float itemSlotCellSize = 25f;
        //    foreach (Item item in inventory.GetItemList())
        //    {
        //        RectTransform itemSlotRectTransform = Instantiate(craftingItemSlotTemplate, craftingItemSlotContainer).GetComponent<RectTransform>();
        //        itemSlotRectTransform.gameObject.SetActive(true);
        //
        //        itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () =>
        //        {
        //            //Use item
        //            inventory.UseItem(item);
        //        };
        //        itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () =>
        //        {
        //            //Drop item
        //            Item duplicateItem = new Item { itemType = item.itemType, amount = item.amount };
        //            inventory.RemoveItem(item);
        //            ItemWorld.DropItem(player.GetPosition(), duplicateItem);
        //        };
        //
        //        itemSlotRectTransform.anchoredPosition = new Vector2(xC * itemSlotCellSize, yC * itemSlotCellSize);
        //        Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
        //        image.sprite = item.GetSprite();
        //
        //        TextMeshProUGUI uiText = itemSlotRectTransform.Find("amountTextCraft").GetComponent<TextMeshProUGUI>();
        //        if (item.amount > 1)
        //        {
        //            uiText.SetText(item.amount.ToString());
        //        }
        //        else
        //        {
        //            uiText.SetText("");
        //        }
        //
        //        //El "ProyectileColider" del Player afecta en el recojo de los objetos
        //        //ya que hace que cuente como 2 recogidas en vez de una
        //
        //        xC++;
        //        //if (xC > 4)
        //        //{
        //        //    xC = 0;
        //        //    yC--;
        //        //}
        //    }
        //}

        //--------------------------------

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
    //    itemTransform.GetComponent<Item>().SetItem(item); //
    //}
    //
    //private void CreateItemOutput(Item item)
    //{
    //    Transform itemTransform = Instantiate(pfItemWorld, itemContainer);
    //    RectTransform itemRectTransform = itemTransform.GetComponent<RectTransform>();
    //    itemRectTransform.anchoredPosition = outputSlotTransform.GetComponent<RectTransform>().anchoredPosition;
    //    itemTransform.GetComponent<Item>().SetItem(item); //
    //}
}
