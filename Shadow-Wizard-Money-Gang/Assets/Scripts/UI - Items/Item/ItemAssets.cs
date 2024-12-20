using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld;
    
    public Transform pfUI_Item; //Test
    
    public Sprite swordSprite;
    public Sprite ghastTearSprite;
    public Sprite spiderEyeSprite;
    public Sprite crystalSprite;
    public Sprite shadowHornSprite;

}
