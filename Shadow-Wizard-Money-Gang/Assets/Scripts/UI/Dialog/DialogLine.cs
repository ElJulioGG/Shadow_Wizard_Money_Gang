using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
namespace DialogSystem
{
    public class DialogLine : DialogBaseClass
    {
        private Text textHolder;

        [Header("Text")]
        [SerializeField]private string input;
        [SerializeField] private Color textColor;
        [SerializeField] private Font textFont;
        [Header("Time Vaariables")]
        [SerializeField] private float delay;
            [SerializeField] private float delayBeetweenLines;

        [Header("Sound Variables")]
        [SerializeField] private AudioClip sound;

        [Header("Character Image")]
        [SerializeField] private Sprite charSprite;
        [SerializeField] private Image imageHolder;
        private bool canClick = false;

        private IEnumerator LineApear;
        private void Awake()
        {
           
          

            imageHolder.sprite = charSprite;
            imageHolder.preserveAspect = true;
            
         
        }
        private void OnEnable()
        {
            ResetLine();
            LineApear = WriteText(input, textHolder, textColor, textFont, delay, sound, delayBeetweenLines);
            StartCoroutine(LineApear);
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space)&&canClick)
            {
                if(textHolder.text != input)
                {
                    StopCoroutine(LineApear);
                    textHolder.text = input;                   
                }
                else
                {
                    finished = true;
                }
            }
        }
        private void ResetLine()
        {
            textHolder = GetComponent<Text>();
            textHolder.text = "";
            finished = false;
        }
    }

   
}