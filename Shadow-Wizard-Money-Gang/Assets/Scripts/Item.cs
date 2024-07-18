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

}
