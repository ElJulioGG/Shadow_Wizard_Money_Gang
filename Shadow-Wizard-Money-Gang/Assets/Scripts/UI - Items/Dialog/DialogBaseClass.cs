using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DialogSystem
{
    public class DialogBaseClass : MonoBehaviour
    {
        public bool finished { get; protected set; }
        protected IEnumerator WriteText(string input, Text textHolder, Color textColor, Font textFont , float delay, AudioClip soundEffect, float delayBeetweenLines)
        {
            textHolder.color = textColor;
            textHolder.font = textFont; 
            for (int i = 0; i < input.Length; i++)
            {
                textHolder.text +=  input[i];
                SoundDialogManager.instance.PlaySound(soundEffect);
                yield return new WaitForSeconds(delay);
            }
            //yield return new WaitForSeconds(delayBeetweenLines);
            yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.E)); 
            finished = true;
        }
    }
}
