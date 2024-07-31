using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronInteract : MonoBehaviour
{
    [SerializeField] private GameObject canvasAlchemy;
    [SerializeField] private Animator animator;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(Input.GetKey(KeyCode.E))
            {
                if (GameManager.instance.playerCanAlchemy)
                {
                    GameManager.instance.playerCanAlchemy = false;
                    canvasAlchemy.SetActive(true);
                }
            }
        }
    }
    private void Update()
    {
        if(GameManager.instance.playerCanAlchemy)
        {
            animator.SetBool("canAlchemy", true);
        }
        else
        {
            animator.SetBool("canAlchemy", false);
        }
    }
}
