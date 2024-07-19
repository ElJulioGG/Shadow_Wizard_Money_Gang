using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
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

}
