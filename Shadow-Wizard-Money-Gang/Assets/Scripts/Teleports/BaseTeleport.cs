using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTeleport : MonoBehaviour
{
    public GameObject destination;
    private GameObject player;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    [SerializeField] private float offsetZ;
    [SerializeField] private int lastTeleportedFrom;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //offsetDestination = new Vector3(destination.transform.position.x, destination.transform.position.y, destination.transform.position.z);
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.position = new Vector3(destination.transform.position.x + offsetX, destination.transform.position.y + offsetY, destination.transform.position.z + offsetZ);
            GameManager.instance.LastTeleportedFrom = lastTeleportedFrom;
        }
    }
}
