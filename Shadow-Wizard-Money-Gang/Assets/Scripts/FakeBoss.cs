using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBoss : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    [SerializeField] private float decentSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("bossDestroy", 5f);
        rb.AddForce(Vector2.down* decentSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void bossDestroy()
    {
        Destroy(gameObject);
    }
}
