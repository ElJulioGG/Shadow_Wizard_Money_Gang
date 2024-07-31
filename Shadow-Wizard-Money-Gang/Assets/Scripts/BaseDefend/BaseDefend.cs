using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDefend : MonoBehaviour
{
    [SerializeField] private GameObject[] spawners;
    [SerializeField]private float defenseDuration;
    [SerializeField] private GameObject canvasDarken;
    [SerializeField] private AreaManager areaManager;
    public bool musicPlayed = false;
    public bool victoryMusicPlayed = false;
    [SerializeField] private bool playerHasEntered;
    private float defenseTimer;

    void Start()
    {
        playerHasEntered = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"&& !playerHasEntered)
        {
            playerHasEntered = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (playerHasEntered)
        {
            canvasDarken.SetActive(true);
            if (!musicPlayed)
            {
                MusicManager.instance.setMusic("DefendBase");
                musicPlayed = true;
            }
           
            if (defenseTimer < ((defenseDuration * 25)) / 100) //25% de la duracion total
            {
                spawners[0].SetActive(true);
            }
            else
            if (defenseTimer < ((defenseDuration * 50)) / 100) //25% de la duracion total
            {
                spawners[1].SetActive(true);
            }
            else
            if (defenseTimer < ((defenseDuration * 75)) / 100) //25% de la duracion total
            {
                spawners[2].SetActive(true);
            }
            else
            if (defenseTimer < defenseDuration) //25% de la duracion total
            {
                spawners[3].SetActive(true);
            }
            else
            if(defenseTimer >= defenseDuration)
            {
                foreach(GameObject spawner in spawners)
                {
                    spawner.SetActive(false);
                }
                
                canvasDarken.SetActive(false);
                areaManager.baseWin();
                if (!victoryMusicPlayed)
                {

                    AudioManager.instance.PlaySfx2("DefendVictory");
                    AudioManager.instance.musicSource.Stop();
                    MusicManager.instance.musicDelayTransition("Aftermath", 4f);
                    victoryMusicPlayed = true;
                }

                GameManager.instance.playerCanAlchemy = true;
                //Destroy(gameObject, 10f);
                gameObject.SetActive(false);
                
            }
            defenseTimer += Time.deltaTime;
        }
    }
  


}
