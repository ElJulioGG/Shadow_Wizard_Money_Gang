using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorText : MonoBehaviour
{
    [SerializeField] private Text errorText;
    // Start is called before the first frame update
    
    private void OnEnable()
    {
        errorText.text = "You don't have enough, try again!";
        Invoke("textHide", 2f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void textHide()
    {
        gameObject.SetActive(false);
    }
}
