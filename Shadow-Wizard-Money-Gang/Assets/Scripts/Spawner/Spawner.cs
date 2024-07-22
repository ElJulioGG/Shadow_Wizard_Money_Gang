using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Collider2D collider; // The 2D collider where you want to instantiate the object
    public GameObject[] Enemies; // The object you want to instantiate
   

    public float spawnRate = 1f;
    private float timer = 0f;

    void Start()
    {
        
    }
    //tilin
    private void Update()
    {
        if(timer >= spawnRate)
        {
            Vector2 randomPoint = GetRandomPointInCollider(collider);
            if (randomPoint != Vector2.zero)
            {
                Instantiate(Enemies[Random.Range(0, Enemies.Length)], randomPoint, Quaternion.identity); ;
            }
            timer = 0f;
        }
        timer += Time.deltaTime;
    }
    Vector2 GetRandomPointInCollider(Collider2D collider)
    {
        Bounds bounds = collider.bounds;
        Vector2 randomPoint = Vector2.zero;
        bool pointFound = false;
        int maxAttempts = 10;
        int attempts = 0;

        while (!pointFound && attempts < maxAttempts)
        {
            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomY = Random.Range(bounds.min.y, bounds.max.y);
            randomPoint = new Vector2(randomX, randomY);

            if (collider.OverlapPoint(randomPoint))
            {
                pointFound = true;
            }
            attempts++;
        }

        if (!pointFound)
        {
            Debug.LogWarning("Could not find a valid point inside the collider after several attempts.");
        }

        return randomPoint;
    }
}
