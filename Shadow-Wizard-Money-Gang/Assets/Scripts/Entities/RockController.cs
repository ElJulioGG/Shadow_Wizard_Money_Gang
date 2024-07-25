using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    [SerializeField] private GameObject destroyParticles;
    [SerializeField] private Sprite rubleSprite;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Atack1")
        {
            destroyRock();
        }
    }
    private void destroyRock()
    {
        AudioManager.instance.PlaySfx("RockDestroy");
        Instantiate(destroyParticles, transform.position, Quaternion.identity);
        Instantiate(rubleSprite, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
