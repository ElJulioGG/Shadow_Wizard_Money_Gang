using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem
{
    public const int GRID_SIZE = 3;

    public event EventHandler OnGridChanged;

    private Item.ItemType[,] potionRecipe;

    private Item[,] itemArray;

    private Item outputItem;

    public CraftingSystem()
    {
        itemArray = new Item[GRID_SIZE, GRID_SIZE];

        potionRecipe = new Item.ItemType[GRID_SIZE, GRID_SIZE];
        potionRecipe[0, 2] = Item.ItemType.None;    potionRecipe[1, 2] = Item.ItemType.GhastTear;   potionRecipe[2, 2] = Item.ItemType.None;
        potionRecipe[0, 1] = Item.ItemType.None;    potionRecipe[1, 1] = Item.ItemType.None;        potionRecipe[2, 1] = Item.ItemType.None;
        potionRecipe[0, 0] = Item.ItemType.None;    potionRecipe[1, 0] = Item.ItemType.None;        potionRecipe[2, 0] = Item.ItemType.None;
    }

    public bool IsEmpty(int x, int y)
    {
        return itemArray[x, y] == null;
    }

    public Item GetItem(int x, int y)
    {
        return itemArray[x, y];
    }

    public void SetItem(Item item, int x, int y)
    {
        itemArray[x, y] = item;
        CreateOutput();
        OnGridChanged?.Invoke(this, EventArgs.Empty);
    }

    private void IncreaseItemAmount(int x, int y)
    {
        GetItem(x, y).amount++;
        OnGridChanged?.Invoke(this, EventArgs.Empty);
    }

    private void DecreaseItemAmount(int x, int y)
    {
        GetItem(x, y).amount--;
        OnGridChanged?.Invoke(this, EventArgs.Empty);
    }

    private void RemoveItem(int x, int y)
    {
        SetItem(null, x, y);
    }

    public bool TryAddItem(Item item, int x, int y)
    {
        if (IsEmpty(x, y))
        {
            SetItem(item, x, y);
            return true;
        }
        else
        {
            if (item.itemType == GetItem(x, y).itemType) //Aqui
            {
                IncreaseItemAmount(x, y);
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private Item.ItemType GetRecipeOutput()
    {
        for (int x = 0; x < GRID_SIZE; x++)
        {
            for (int y = 0; y < GRID_SIZE; y++)
            {
                if (potionRecipe[x, y] != Item.ItemType.None)
                {
                    //Recipe has Item in this position
                    if (IsEmpty(x, y) || GetItem(x, y).itemType != potionRecipe[x, y])
                    {
                        //Empty position or different itemType
                        return Item.ItemType.None;
                        Debug.Log("Crafteaste una pocion");
                    }
                }
            }
        }
        return Item.ItemType.Crystal;
    }

    private void CreateOutput()
    {
        Item.ItemType recipeOutput = GetRecipeOutput();
        if (recipeOutput == Item.ItemType.None)
        {
            outputItem = null;
        }
        else
        {
            outputItem = new Item { itemType = recipeOutput };
        }
    }

    public Item GetOutputItem()
    {
        return outputItem;
    }

}
