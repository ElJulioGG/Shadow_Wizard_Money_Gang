using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AreaTriggerEvents : MonoBehaviour
{
    [Header("Spanwers")]
    [SerializeField] private GameObject[] spawners;
    [SerializeField]  private GameObject caldero;
    // Start is called before the first frame update

    public UnityEvent areaTriggerEvent;
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
            areaTriggerEvent.Invoke();
        }
    }

    
    public void ObjectDestroy()
    {
        Destroy(gameObject);    
    }
    public void startSpawners()
    {
        foreach (GameObject spawner in spawners) { spawner.SetActive(true); }
    }
  
    public void stopAllSpawners()
    {
        foreach (GameObject spawner in spawners) { spawner.SetActive(false); }
    }
    public void cerrarCaldero()
    {
       caldero.SetActive(false);
    }
    public void musicExploreAndFigth()
    {
        AudioManager.instance.musicSource.Stop();
        AudioManager.instance.PlayMusic("Explore&Fight");
    }

}
