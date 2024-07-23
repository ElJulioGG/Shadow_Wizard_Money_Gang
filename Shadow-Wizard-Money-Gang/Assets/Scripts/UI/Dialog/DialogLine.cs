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
        private void Awake()
        {
           
            textHolder = GetComponent<Text>();
            textHolder.text = "";

            imageHolder.sprite = charSprite;
            imageHolder.preserveAspect = true;
            
         
        }
        private void Start()
        {
            StartCoroutine(WriteText(input, textHolder, textColor, textFont, delay, sound, delayBeetweenLines));
        }
    }

   
}