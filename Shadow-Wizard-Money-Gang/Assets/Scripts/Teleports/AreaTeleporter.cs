using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AreaTeleporter : MonoBehaviour
{
    [SerializeField] private GameObject destination;
    private GameObject player;
    
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    [SerializeField] private float offsetZ;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
         
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //player.transform.position = destination.transform.position;
        if (collision.gameObject.tag == "Player")
        {
            destination = null;
            if (gameObject.tag == "TeleportTower")
            { 
                switch (GameManager.instance.basesDefended)
                {
                    case 0:
                        destination = GameObject.FindGameObjectWithTag("BaseTeleport1");
                        player.transform.position = new Vector3(destination.transform.position.x + offsetX, destination.transform.position.y + offsetY, destination.transform.position.z + offsetZ);
                        break;
                    case 1:
                        destination = GameObject.FindGameObjectWithTag("BaseTeleport2");
                        player.transform.position = new Vector3(destination.transform.position.x + offsetX, destination.transform.position.y + offsetY, destination.transform.position.z + offsetZ);
                        break;
                    case 2:
                        destination = GameObject.FindGameObjectWithTag("BaseTeleport3");
                        player.transform.position = new Vector3(destination.transform.position.x + offsetX, destination.transform.position.y + offsetY, destination.transform.position.z + offsetZ);
                        break;
                    case 3:
                        destination = GameObject.FindGameObjectWithTag("BaseTeleport4");
                        player.transform.position = new Vector3(destination.transform.position.x + offsetX, destination.transform.position.y + offsetY, destination.transform.position.z + offsetZ);
                        break;
                    case 4:
                        destination = GameObject.FindGameObjectWithTag("BaseTeleport5");
                        player.transform.position = new Vector3(destination.transform.position.x + offsetX, destination.transform.position.y + offsetY, destination.transform.position.z + offsetZ);
                        break;
                }
            }
        }
    }
}
