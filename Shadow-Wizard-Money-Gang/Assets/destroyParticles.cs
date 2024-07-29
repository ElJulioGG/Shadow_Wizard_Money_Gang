using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyParticles : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float destroyTime;
    void Start()
    {
        Invoke("particleDestroy", destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void particleDestroy()
    {
        Destroy(gameObject);
    }
}
