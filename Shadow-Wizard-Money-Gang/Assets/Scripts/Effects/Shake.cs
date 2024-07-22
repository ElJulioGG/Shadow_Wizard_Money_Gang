using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public float shakeSpeed = 1.0f;
    public float shakeIntensity = 1.0f;
    public float shakeDuration = 1.0f;

    private Vector2 startingPos;
    private float shakeTime = 0.0f;

    void Awake()
    {
        startingPos = transform.position;
    }

    // Start the shake effect
    public void StartShake()
    {
        shakeTime = shakeDuration;
    }

    void Update()
    {
        if (shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;
            float currentShakeIntensity = shakeIntensity * (shakeTime / shakeDuration);

            Vector2 newTransform;
            newTransform.x = startingPos.x + (Mathf.PerlinNoise(Time.time * shakeSpeed, 0.0f) - 0.5f) * currentShakeIntensity * 2.0f;
            newTransform.y = startingPos.y + (Mathf.PerlinNoise(0.0f, Time.time * shakeSpeed) - 0.5f) * currentShakeIntensity * 2.0f;

            transform.position = newTransform;
        }
        else
        {
            transform.position = startingPos;
        }
    }
}