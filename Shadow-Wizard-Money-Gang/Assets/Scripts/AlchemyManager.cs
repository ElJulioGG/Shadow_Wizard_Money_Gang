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
    [SerializeField] private GameObject panel;
    [SerializeField] private Button boton;

    [SerializeField] private float introDuration =1f;

    [SerializeField] private GameObject errorImage;
    [SerializeField] private Animator animatorCanvas;
    [SerializeField] private Animator animatorCauldron;
    [SerializeField] private BuffManager buffManager;
    public string messageBuff;

    private bool hasBrewed = false;
   
    // Start is called before the first frame update
    private void Start()
    {
        setStringsToText();
       
    }
    private void OnEnable()
    {
        setStringsToText();
        StartCoroutine(IntroCourrtine());
       
    }
    private IEnumerator IntroCourrtine()
    {
        
        yield return new WaitForSeconds(introDuration);
        panel.SetActive(true);
        animatorCanvas.SetTrigger("Intro");

    }
    private IEnumerator OutroCourrtine()
    {
        print("lol");
        animatorCauldron.SetTrigger("Animate");
       
        boton.enabled = false;
        yield return new WaitForSeconds(introDuration);
        animatorCanvas.SetTrigger("Outro");
        
        panel.SetActive(false);
        yield return new WaitForSeconds(introDuration);
        gameObject.SetActive(false);
        boton.enabled = true;
        print("lmao");

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

                    hasBrewed = true;
                    messageBuff = "Soy potion: More bullets, less damage";
                    buffManager.Buff1();
                    print("Potion0");
                }
                else
                {
                    errorImage.SetActive(true);

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
                    messageBuff = "GainsMaxxer Potion: Chunky body, bad mobility";
                    buffManager.Buff2();
                    hasBrewed = true;
                }
                else
                {
                    errorImage.SetActive(true);
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
                    buffManager.Buff3();
                    messageBuff = ": Double Projectiles!";
                    hasBrewed = true;
                }
                else
                {
                    errorImage.SetActive(true);
                }
                break;

            case 3:
                if (GameManager.instance.material3 >= 4 && GameManager.instance.material4 >= 3)
                {
                    GameManager.instance.material3 = GameManager.instance.material3 - 4;
                    GameManager.instance.material4 = GameManager.instance.material4 - 3;
                    print("Potion3");
                    messageBuff = ": PiercingShot + dmg a bit down";
                    buffManager.Buff4();
                    hasBrewed = true;
                }
                else
                {
                    errorImage.SetActive(true);
                }
                break;
            case 4:
                if (GameManager.instance.material1 >= 2 && GameManager.instance.material4 >= 5)
                {
                    GameManager.instance.material1 = GameManager.instance.material1 - 2;
                    GameManager.instance.material4 = GameManager.instance.material4 - 5;
                    print("Potion4");
                    hasBrewed = true;
                }
                else
                {
                    errorImage.SetActive(true);
                }
                break;
            case 5:
                if (GameManager.instance.material1 >= 2 && GameManager.instance.material2 >= 2 && GameManager.instance.material4 >= 4)
                {
                    GameManager.instance.material1 = GameManager.instance.material1 - 2;
                    GameManager.instance.material2 = GameManager.instance.material2 - 2;
                    GameManager.instance.material4 = GameManager.instance.material4 - 4;
                    hasBrewed = true;
                    print("Potion5");
                }
                else
                {
                    errorImage.SetActive(true);
                }
                break;
            case 6:
                if (GameManager.instance.material1 >= 7 && GameManager.instance.material4 >= 1)
                {
                    GameManager.instance.material1 = GameManager.instance.material1 - 7;
                    GameManager.instance.material4 = GameManager.instance.material4 - 1;
                    print("Potion6");
                    hasBrewed = true;
                }
                else
                ///qwdawda
                {
                    errorImage.SetActive(true);
                }
                break;
            case 7:
                if (GameManager.instance.material2 >= 3 && GameManager.instance.material3 >= 3)
                {
                    GameManager.instance.material2 = GameManager.instance.material2 - 3;
                    GameManager.instance.material3 = GameManager.instance.material3 - 3;
                    hasBrewed = true;
                    print("Potion7");
                }
                else
                {
                    errorImage.SetActive(true);
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
                    hasBrewed = true;
                }
                else
                {
                    errorImage.SetActive(true);
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
                    hasBrewed = true;
                }
                else
                {
                    errorImage.SetActive(true);
                }
                break;

        }
        setStringsToText();
        if(hasBrewed)
        {
            StartCoroutine(OutroCourrtine());
        }

    }

    private void setStringsToText()
    {
        text0.text = GameManager.instance.material1.ToString();
        text1.text = GameManager.instance.material2.ToString();
        text2.text = GameManager.instance.material3.ToString();
        text3.text = GameManager.instance.material4.ToString();
    }
}
