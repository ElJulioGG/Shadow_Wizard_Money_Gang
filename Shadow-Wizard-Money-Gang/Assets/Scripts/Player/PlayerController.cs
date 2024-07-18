using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float activeMoveSpeed = 1f;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float dashMoveSpeed = 2f;
    [SerializeField] private float dashDuration = 0.5f;
    [SerializeField] private float dashCooldown = 0.5f;
    //[SerializeField] private UI_Inventory uiInventory;


    public bool isDashing;

    [SerializeField] private Vector2 movement;
    private PlayerControls playerControls;
   
    private Rigidbody2D rb;

    //Inventory stuff
    private InventoryManager inventory;

    private void Start()
    {
        activeMoveSpeed = moveSpeed;
    }
    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();

        inventory = new InventoryManager();

        //uiInventory.SetInventory(inventory);
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        if (isDashing)
        {
            return;
        }
        
        PlayerInput();
        if (Input.GetKeyDown(KeyCode.Space)&& movement != Vector2.zero)
        {
            StartCoroutine(Roll());
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        Move();
       
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
    }
    private void Move()
    {
        rb.MovePosition(rb.position + movement * (activeMoveSpeed * Time.fixedDeltaTime));
    }

    private IEnumerator Roll()
    {
        isDashing = true;
        rb.velocity = new Vector2(movement.x * dashMoveSpeed, movement.y * dashMoveSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
    }
}
