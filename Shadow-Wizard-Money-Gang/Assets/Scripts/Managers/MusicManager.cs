using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private void Start()
    {
        // if escena is "menu" then play(MenuMusic :p)
        //else
        setMusicAftermath();
    }
    public void setMusicAftermath()
    {
        AudioManager.instance.PlayMusic("Aftermath");
    }
    public void setMusicMenu()
    {
        AudioManager.instance.PlayMusic("MenuMusic");
    }
    public void setMusicExploreFight()
    {
        AudioManager.instance.PlayMusic("Explore&Fight");
    }
}
