using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class AlchemyManager : MonoBehaviour
{
    [SerializeField] private Text text0;
    [SerializeField] private Text text1;
    [SerializeField] private Text text2;
    [SerializeField] private Text text3;

    // Start is called before the first frame update
    private void Start()
    {
        setStringsToText();
    }
    public void CreatePotion()
    {
        print("Reroll");
        System.Random random = new System.Random();
        int randomInt = random.Next(0, 10);
   
        switch (randomInt)
        {

            case 0:
                if (GameManager.instance.material1 >= 6)
                {
                    GameManager.instance.material1 = GameManager.instance.material1 - 6;

                    print("Potion0");
                }
                else
                {
                    CreatePotion();
                    
                }
                break;
            case 1:
                if (GameManager.instance.material1 >= 2 && GameManager.instance.material2>= 2 && GameManager.instance.material3 >= 2 && GameManager.instance.material4 >= 2)
                {
                    GameManager.instance.material1 = GameManager.instance.material1 - 2;
                    GameManager.instance.material2 = GameManager.instance.material2 - 2;
                    GameManager.instance.material3 = GameManager.instance.material3 - 2;
                    GameManager.instance.material4 = GameManager.instance.material4 - 2;
                    print("Potion1");
                }
                else
                {
                    CreatePotion();
                }
                break;
            case 2:
                if (GameManager.instance.material1 >= 1 && GameManager.instance.material2 >= 1 && GameManager.instance.material3 >= 3 && GameManager.instance.material4 >= 3)
                {
                    GameManager.instance.material1 = GameManager.instance.material1 - 1;
                    GameManager.instance.material2 = GameManager.instance.material2 - 1;
                    GameManager.instance.material3 = GameManager.instance.material3 - 3;
                    GameManager.instance.material4 = GameManager.instance.material4 - 3;
                    print("Potion2");
                }
                else
                {
                    CreatePotion();
                }
                break;

            case 3:
                if (GameManager.instance.material3 >= 4 && GameManager.instance.material4 >= 3)
                {
                    GameManager.instance.material3 = GameManager.instance.material3 - 4;
                    GameManager.instance.material4 = GameManager.instance.material4 - 3;
                    print("Potion3");
                }
                else
                {
                    CreatePotion();
                }
                break;
            case 4:
                if (GameManager.instance.material1 >= 2 && GameManager.instance.material4 >= 5)
                {
                    GameManager.instance.material1 = GameManager.instance.material1 - 2;
                    GameManager.instance.material4 = GameManager.instance.material4 - 5;
                    print("Potion4");
                }
                else
                {
                    CreatePotion();
                }
                break;
            case 5:
                if (GameManager.instance.material1 >= 2 && GameManager.instance.material2 >= 2 && GameManager.instance.material4 >= 4)
                {
                    GameManager.instance.material1 = GameManager.instance.material1 - 2;
                    GameManager.instance.material2 = GameManager.instance.material2 - 2;
                    GameManager.instance.material4 = GameManager.instance.material4 - 4;

                    print("Potion5");
                }
                else
                {
                    CreatePotion();
                }
                break;
            case 6:
                if (GameManager.instance.material1 >= 7 && GameManager.instance.material4 >= 1)
                {
                    GameManager.instance.material1 = GameManager.instance.material1 - 7;
                    GameManager.instance.material4 = GameManager.instance.material4 - 1;
                    print("Potion6");
                }
                else
                ///qwdawda
                {
                    CreatePotion();
                }
                break;
            case 7:
                if (GameManager.instance.material2 >= 3 && GameManager.instance.material3 >= 3)
                {
                    GameManager.instance.material2 = GameManager.instance.material2 - 3;
                    GameManager.instance.material3 = GameManager.instance.material3 - 3;

                    print("Potion7");
                }
                else
                {
                    CreatePotion();
                }
                break;
            case 8:
                if (GameManager.instance.material1 >= 4 && GameManager.instance.material2 >= 4 && GameManager.instance.material3 >= 4 && GameManager.instance.material4 >= 4)
                {
                    GameManager.instance.material1 = GameManager.instance.material1 - 4;
                    GameManager.instance.material2 = GameManager.instance.material2 - 4;
                    GameManager.instance.material3 = GameManager.instance.material3 - 4;
                    GameManager.instance.material4 = GameManager.instance.material4 - 4;
                    print("Potion8");
                }
                else
                {
                    CreatePotion();
                }
                break;
            case 9:
                if (GameManager.instance.material1 >= 4 && GameManager.instance.material2 >= 1 && GameManager.instance.material3 >= 4 && GameManager.instance.material4 >= 2)
                {
                    GameManager.instance.material1 = GameManager.instance.material1 - 4;
                    GameManager.instance.material2 = GameManager.instance.material2 - 1;
                    GameManager.instance.material3 = GameManager.instance.material3 - 4;
                    GameManager.instance.material4 = GameManager.instance.material4 - 2;
                    print("Potion9");
                }
                else
                {
                    CreatePotion();
                }
                break;

        }
        setStringsToText();

    }

    private void setStringsToText()
    {
        text0.text = GameManager.instance.material1.ToString();
        text1.text = GameManager.instance.material2.ToString();
        text2.text = GameManager.instance.material3.ToString();
        text3.text = GameManager.instance.material4.ToString();
    }
}
