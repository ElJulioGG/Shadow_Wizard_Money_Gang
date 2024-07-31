using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject text1;
    [SerializeField] GameObject text2;
    [SerializeField] GameObject text3;
    [SerializeField] Animator canvasAnimator;
    [SerializeField] GameObject fakeBoss;
    
    void Start()
    {
        AudioManager.instance.musicSource.Stop();
        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
        StartCoroutine(IntroCorrutine());
        GameManager.instance.playerCanInput = false;
        GameManager.instance.playerCanMove = false;
        GameManager.instance.playerCanAtack = false;
        AudioManager.instance.musicSource.Stop();
        AudioManager.instance.PlayMusic("IntroMusic");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator IntroCorrutine()
    {
        yield return new WaitForSeconds(1f);
        text1.SetActive(true);
        yield return new WaitForSeconds(4f);
        text2.SetActive(true);
        yield return new WaitForSeconds(4f);
        text3.SetActive(true);
        yield return new WaitForSeconds(4f);
        AudioManager.instance.PlayMusic("Aftermath");
        canvasAnimator.SetTrigger("FadeOut");
        fakeBoss.SetActive(true);
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        GameManager.instance.playerCanInput = true;
        GameManager.instance.playerCanMove = true;
        GameManager.instance.playerCanAtack = true;
    }
}
