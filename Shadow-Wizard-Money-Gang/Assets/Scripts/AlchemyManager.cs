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
    [SerializeField] private GameObject  canvasText;
    [SerializeField] private Text Text;

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
        AudioManager.instance.PlaySfx("BrewAccept");
        animatorCauldron.SetTrigger("Animate");
       
        boton.enabled = false;
        yield return new WaitForSeconds(introDuration);
        animatorCanvas.SetTrigger("Outro");
        
        panel.SetActive(false);
        yield return new WaitForSeconds(introDuration);
        gameObject.SetActive(false);
        boton.enabled = true;


        

    }
    public void CreatePotion()
    {
        
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
                    print(messageBuff);
                    StartCoroutine(corrutinaText());


                }
                else
                {
                    errorImage.SetActive(true);
                    AudioManager.instance.PlaySfx("BrewDeny");

                }
                break;
            case 1:
                if (GameManager.instance.material1 >= 2 && GameManager.instance.material2>= 2 && GameManager.instance.material3 >= 2 && GameManager.instance.material4 >= 2)
                {
                    GameManager.instance.material1 = GameManager.instance.material1 - 2;
                    GameManager.instance.material2 = GameManager.instance.material2 - 2;
                    GameManager.instance.material3 = GameManager.instance.material3 - 2;
                    GameManager.instance.material4 = GameManager.instance.material4 - 2;
                   
                    messageBuff = "GainsMaxxer Potion: Chunky body, bad mobility";
                    buffManager.Buff2();
                    hasBrewed = true;
                    print(messageBuff);
                    StartCoroutine(corrutinaText());
                }
                else
                {
                    errorImage.SetActive(true);
                    AudioManager.instance.PlaySfx("BrewDeny");
                }
                break;
            case 2:
                if (GameManager.instance.material1 >= 1 && GameManager.instance.material2 >= 1 && GameManager.instance.material3 >= 3 && GameManager.instance.material4 >= 3)
                {
                    GameManager.instance.material1 = GameManager.instance.material1 - 1;
                    GameManager.instance.material2 = GameManager.instance.material2 - 1;
                    GameManager.instance.material3 = GameManager.instance.material3 - 3;
                    GameManager.instance.material4 = GameManager.instance.material4 - 3;
                    
                    buffManager.Buff3();
                    messageBuff = "Double Projectiles!, don't get hit";
                    hasBrewed = true;
                    print(messageBuff);
                    StartCoroutine(corrutinaText());
                }
                else
                {
                    errorImage.SetActive(true);
                    AudioManager.instance.PlaySfx("BrewDeny");
                }
                break;

            case 3:
                if (GameManager.instance.material3 >= 4 && GameManager.instance.material4 >= 3)
                {
                    GameManager.instance.material3 = GameManager.instance.material3 - 4;
                    GameManager.instance.material4 = GameManager.instance.material4 - 3;
                    
                    messageBuff = "PiercingShot + dmg a bit down";
                    buffManager.Buff4();
                    hasBrewed = true;
                    print(messageBuff);
                    StartCoroutine(corrutinaText());
                }
                else
                {
                    errorImage.SetActive(true);
                    AudioManager.instance.PlaySfx("BrewDeny");
                }
                break;
            case 4:
                if (GameManager.instance.material1 >= 2 && GameManager.instance.material4 >= 5)
                {
                    GameManager.instance.material1 = GameManager.instance.material1 - 2;
                    GameManager.instance.material4 = GameManager.instance.material4 - 5;
                  
                    messageBuff = "Beeg flufin blast: B";
                    buffManager.Buff5();
                    hasBrewed = true;
                    print(messageBuff);
                    StartCoroutine(corrutinaText());
                }
                else
                {
                    errorImage.SetActive(true);
                    AudioManager.instance.PlaySfx("BrewDeny");
                }
                break;
            case 5:
                if (GameManager.instance.material1 >= 2 && GameManager.instance.material2 >= 2 && GameManager.instance.material4 >= 4)
                {
                    GameManager.instance.material1 = GameManager.instance.material1 - 2;
                    GameManager.instance.material2 = GameManager.instance.material2 - 2;
                    GameManager.instance.material4 = GameManager.instance.material4 - 4;
                    hasBrewed = true;
                    messageBuff = "I am speed, - damage";
                    buffManager.Buff6();
                    print(messageBuff);
                    StartCoroutine(corrutinaText());
                }
                else
                {
                    errorImage.SetActive(true);
                    AudioManager.instance.PlaySfx("BrewDeny");
                }
                break;
            case 6:
                if (GameManager.instance.material1 >= 7 && GameManager.instance.material4 >= 1)
                {
                    GameManager.instance.material1 = GameManager.instance.material1 - 7;
                    GameManager.instance.material4 = GameManager.instance.material4 - 1;
                   
                    messageBuff = "Synced attacks";
                    buffManager.Buff7();
                    hasBrewed = true;
                    print(messageBuff);
                    StartCoroutine(corrutinaText());
                }
                else
                ///qwdawda
                {
                    errorImage.SetActive(true);
                    AudioManager.instance.PlaySfx("BrewDeny");
                }
                break;
            case 7:
                if (GameManager.instance.material2 >= 3 && GameManager.instance.material3 >= 3)
                {
                    GameManager.instance.material2 = GameManager.instance.material2 - 3;
                    GameManager.instance.material3 = GameManager.instance.material3 - 3;
                    hasBrewed = true;
                    messageBuff = "Shield UP, take a bit of damage";
                    buffManager.Buff8();
                    print(messageBuff);
                    StartCoroutine(corrutinaText());
                }
                else
                {
                    AudioManager.instance.PlaySfx("BrewDeny");
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
                    messageBuff = "All Stats UP!!! Lucky You!!!";
                    buffManager.Buff9();
                    print(messageBuff);
                    hasBrewed = true;
                    StartCoroutine(corrutinaText());
                }
                else
                {
                    errorImage.SetActive(true);
                    AudioManager.instance.PlaySfx("BrewDeny");
                }
                break;
            case 9:
                if (GameManager.instance.material1 >= 4 && GameManager.instance.material2 >= 1 && GameManager.instance.material3 >= 4 && GameManager.instance.material4 >= 2)
                {
                    GameManager.instance.material1 = GameManager.instance.material1 - 4;
                    GameManager.instance.material2 = GameManager.instance.material2 - 1;
                    GameManager.instance.material3 = GameManager.instance.material3 - 4;
                    GameManager.instance.material4 = GameManager.instance.material4 - 2;
                    
                    hasBrewed = true;
                    messageBuff = "Bullet Hell!!! Worse Roll, Smaller Htibox";
                    print(messageBuff);
                    buffManager.Buff10();
                    StartCoroutine(corrutinaText());
                }
                else
                {
                    AudioManager.instance.PlaySfx("BrewDeny");
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
    private IEnumerator corrutinaText()
    {
        canvasText.SetActive(true);
        Text.text = messageBuff;
        yield return new WaitForSeconds(4f);
        canvasText.SetActive(false);
    }
}
