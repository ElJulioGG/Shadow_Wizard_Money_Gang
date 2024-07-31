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
            { 5, () => GameManager.instance.BlockOutsideBase1B },
            { 6, () => GameManager.instance.BlockOutsideBase2B },
            { 7, () => GameManager.instance.BlockOutsideBase3B },
            { 8, () => GameManager.instance.BlockOutsideBase1C },
            { 9, () => GameManager.instance.BlockOutsideBase2C },
            { 10, () => GameManager.instance.BlockOutsideBase3C },
            { 11, () => GameManager.instance.BlockOutsideBase1D },
            { 12, () => GameManager.instance.BlockOutsideBase2D },
            { 13, () => GameManager.instance.BlockOutsideBase3D },
            { 14, () => GameManager.instance.BlockOutsideBase1E },
            { 15, () => GameManager.instance.BlockOutsideBase2E }
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
        switch (GameManager.instance.basesDefended) {
            case 0:
                GameManager.instance.BlockOutsideBase1A = false;
                GameManager.instance.BlockOutsideBase2A = false;
                GameManager.instance.BlockOutsideBase1B = false;
                GameManager.instance.blockTower2 = false;
                GameManager.instance.blockTower1 = true;
                GameManager.instance.basesDefended++;
                break;
            case 1:
                GameManager.instance.BlockOutsideBase1B = false;
                GameManager.instance.BlockOutsideBase2B = false;
                GameManager.instance.BlockOutsideBase3B = false;
                GameManager.instance.BlockOutsideBase1C = false;
                GameManager.instance.blockTower2 = false;
                GameManager.instance.blockTower1 = true;
                GameManager.instance.basesDefended++;
                break;
            case 2:
                GameManager.instance.BlockOutsideBase1C = false;
                GameManager.instance.BlockOutsideBase2C = false;
                GameManager.instance.BlockOutsideBase3C = false;
                GameManager.instance.BlockOutsideBase1D = false;
                GameManager.instance.blockTower2 = false;
                GameManager.instance.blockTower1 = true;
                GameManager.instance.basesDefended++;
                break;
            case 3:
                GameManager.instance.BlockOutsideBase1D = false;
                GameManager.instance.BlockOutsideBase2D = false;
                GameManager.instance.BlockOutsideBase3D = false;
                GameManager.instance.BlockOutsideBase1E = false;
                GameManager.instance.blockTower2 = false;
                GameManager.instance.blockTower1 = true;
                GameManager.instance.basesDefended++;
                break;
            case 4:
                GameManager.instance.BlockOutsideBase1E = false;
                GameManager.instance.BlockOutsideBase2E = false;
                GameManager.instance.TeleportBoss = true;
                GameManager.instance.blockTower2 = false;
                GameManager.instance.blockTower1 = true;
                GameManager.instance.basesDefended++;
                break;
        }
            
    }
    
    public void baseClose()
    {
        GameManager.instance.BlockOutsideBase1A = true;
        GameManager.instance.BlockOutsideBase2A = true;
        GameManager.instance.BlockOutsideBase1B = true;
        GameManager.instance.BlockOutsideBase2B = true;
        GameManager.instance.BlockOutsideBase3B = true;
        GameManager.instance.BlockOutsideBase1C = true;
        GameManager.instance.BlockOutsideBase2C = true;
        GameManager.instance.BlockOutsideBase3C = true;
        GameManager.instance.BlockOutsideBase1D = true;
        GameManager.instance.BlockOutsideBase2D = true;
        GameManager.instance.BlockOutsideBase3D = true;
        GameManager.instance.BlockOutsideBase1E = true;
        GameManager.instance.BlockOutsideBase2E = true;

        GameManager.instance.blockTower2 = true;

    }
}

