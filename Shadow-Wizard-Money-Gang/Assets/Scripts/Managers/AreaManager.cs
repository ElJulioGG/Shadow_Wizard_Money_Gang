using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public GameObject[] Blocks;
    public GameObject[] TutorialEnemies;

    private Dictionary<int, System.Func<bool>> blockStateChecks;

    private void Start()
    {
       
        blockStateChecks = new Dictionary<int, System.Func<bool>>
        {
            { 0, () => GameManager.instance.blockPeCausa },
            { 1, () => GameManager.instance.blockTower1 },
            { 2, () => GameManager.instance.blockTower2 },
            { 3, () => GameManager.instance.BlockOutsideBase1A},
            { 4, () => GameManager.instance.BlockOutsideBase2A },
            //{ 5, () => GameManager.instance.BlockOutsideBase2A }
        };
    }//ad
    /// <summary>
    /// w
    /// </summary>
    private void Update()
    {
        for (int i = 0; i < Blocks.Length; i++)
        {
            if (i < blockStateChecks.Count)
            {
                bool shouldBeActive = blockStateChecks[i].Invoke();
                if (Blocks[i].activeInHierarchy != shouldBeActive)
                {
                    Blocks[i].SetActive(shouldBeActive);
                }
            }
        }

        tutorialOpen();
        //baseWin();
    }
    void tutorialOpen()
    {
        bool allEnemiesDestroyed = true;
        for (int i = 0; i < TutorialEnemies.Length; i++)
        {
            if (TutorialEnemies[i] != null && TutorialEnemies[i].activeInHierarchy)
            {
                allEnemiesDestroyed = false;
                break;
            }
        }

        if (allEnemiesDestroyed)
        {
            GameManager.instance.blockTower1 = false;
        }
    }
    public void baseWin()
    {
            GameManager.instance.BlockOutsideBase1A = false;
            GameManager.instance.BlockOutsideBase2A = false;   
            GameManager.instance.blockTower2 = false;
    }
    public void baseClose()
    {
        GameManager.instance.BlockOutsideBase1A = true;
        GameManager.instance.BlockOutsideBase2A = true;
        GameManager.instance.blockTower2 = true;

    }
}

