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
    [SerializeField] private UI_Inventory uiInventory; //Inventory stuff

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

        inventory = new InventoryManager(); //Inventory stuff
        uiInventory.SetInventory(inventory); //Inventory stuff

        //Iniciar con 5 items (Sword, GhastTear, SpiderEye, Crystal, ShadowHorn)
        //ItemWorld.SpawnItemWorld(new Vector3(0, 0),  new Item { itemType = Item.ItemType.Sword, amount = 1 });
        //ItemWorld.SpawnItemWorld(new Vector3(5, 0),  new Item { itemType = Item.ItemType.GhastTear, amount = 1 });
        //ItemWorld.SpawnItemWorld(new Vector3(10, 0), new Item { itemType = Item.ItemType.SpiderEye, amount = 1 });
        //ItemWorld.SpawnItemWorld(new Vector3(15, 0), new Item { itemType = Item.ItemType.Crystal, amount = 1 });
        //ItemWorld.SpawnItemWorld(new Vector3(20, 0), new Item { itemType = Item.ItemType.ShadowHorn, amount = 1 });
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if (itemWorld != null) {
            //Touching Item
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
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
        if (Input.GetKeyDown(KeyCode.Space) && movement != Vector2.zero)
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
        CameraShake.Instance.shakeCamera(5f, .2f);
        yield return new WaitForSeconds(hitRecoveryDuration);
        GameManager.instance.playerInvinsibility = false;
        playerAnimator.SetBool("IsInvincible", false);


    }
}
