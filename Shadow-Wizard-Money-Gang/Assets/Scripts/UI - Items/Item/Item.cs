using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Item 
{
    public enum ItemType
    {
        //Referential item names
        Sword,
        GhastTear,
        SpiderEye,
        Crystal,
        ShadowHorn,
        None,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite() //Aqui
    {
        switch (itemType)
        {
            default:
            case ItemType.Sword:        return ItemAssets.Instance.swordSprite;
            case ItemType.GhastTear:    return ItemAssets.Instance.ghastTearSprite;
            case ItemType.SpiderEye:    return ItemAssets.Instance.spiderEyeSprite;
            case ItemType.Crystal:      return ItemAssets.Instance.crystalSprite;
            case ItemType.ShadowHorn:   return ItemAssets.Instance.shadowHornSprite;
        }
    }

    // Método estático para obtener un sprite basado en itemType
    //public static Sprite GetSprite(ItemType itemType)
    //{
    //    Item tempItem = new Item { itemType = itemType };
    //    return tempItem.GetSprite();
    //}

    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
                case ItemType.Sword: return false;
                case ItemType.GhastTear:return true;
                case ItemType.SpiderEye:return true;
                case ItemType.Crystal:return true;  
                case ItemType.ShadowHorn:return true;
        }
    }




}
