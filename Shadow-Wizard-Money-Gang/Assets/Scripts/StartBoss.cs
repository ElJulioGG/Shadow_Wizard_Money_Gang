using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBoss : MonoBehaviour
{
    [SerializeField] GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            AudioManager.instance.musicSource.Stop();
            AudioManager.instance.PlayMusic("FinalBoss");
            boss.SetActive(true);
            gameObject.SetActive(false);
            
        }
    }
}
