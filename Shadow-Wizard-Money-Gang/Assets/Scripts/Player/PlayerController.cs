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
    [SerializeField] private float hitRecoveryDuration = 0.5f;
    //[SerializeField] private UI_Inventory uiInventory;


    public Animator playerAnimator;
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
        if (GameManager.instance.playerIsHit)
        {
            StartCoroutine(HitRecovery());
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
        playerAnimator.SetBool("IsRolling", true);
        isDashing = true;
        GameManager.instance.playerInvinsibility = true;
        rb.velocity = new Vector2(movement.x * dashMoveSpeed, movement.y * dashMoveSpeed);

        yield return new WaitForSeconds(dashDuration);
        GameManager.instance.playerInvinsibility = false;
        isDashing = false;
        playerAnimator.SetBool("IsRolling", false);
    }
    private IEnumerator HitRecovery()
    {
        playerAnimator.SetBool("IsInvincible", true);
        GameManager.instance.playerIsHit = false;
        GameManager.instance.playerInvinsibility = true;
        GameManager.instance.playerHealth--;
        CameraShake.Instance.shakeCamera(10f,.2f);
        yield return new WaitForSeconds(hitRecoveryDuration);
        GameManager.instance.playerInvinsibility = false;
        playerAnimator.SetBool("IsInvincible", false);


    }
}
