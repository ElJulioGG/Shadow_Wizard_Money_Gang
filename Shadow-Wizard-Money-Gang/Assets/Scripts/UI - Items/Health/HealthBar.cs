using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject heartPrefab;

    List<HearthState> hearts = new List<HearthState>();

    private void FixedUpdate()
    {
        drawHearts();


    }
    private void OnEnable()
    {
        PlayerController.OnPlayerDamaged += drawHearts;
    }
    private void OnDisable()
    {
        PlayerController.OnPlayerDamaged -= drawHearts;
    }
    private void Start()
    {
        drawHearts();
    }
    public void createEmptyHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        HearthState heartComponent = newHeart.GetComponent<HearthState>();
        heartComponent.setHeartImage(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }
   
    public void clearHearts()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HearthState>();
    }
    public void drawHearts()
    {
        clearHearts();

        float maxHealthRemainder = GameManager.instance.playerMaxHealth % 2;
        int heartsToMake = (int)((GameManager.instance.playerMaxHealth / 2) + maxHealthRemainder);

        for (int i = 0; i < heartsToMake; i++) {

            createEmptyHeart();
        }
        for (int i = 0; i < hearts.Count; i++)
        {
            int heartStatusRemainder = (int)Mathf.Clamp(GameManager.instance.playerHealth - (i*2),0,2);
            hearts[i].setHeartImage((HeartStatus)heartStatusRemainder);
        }
    }
}
