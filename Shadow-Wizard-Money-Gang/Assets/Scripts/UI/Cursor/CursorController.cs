using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    Vector2 difference = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        //mouseWorldPosition.z = 0f;

        //transform.position = mouseWorldPosition;
        

        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    }
}
