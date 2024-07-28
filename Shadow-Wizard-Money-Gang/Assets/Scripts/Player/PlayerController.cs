using System;
using System.Collections;

using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem;
using CodeMonkey.Utils;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float activeMoveSpeed = 1f;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float dashMoveSpeed = 2f;
    [SerializeField] private float dashDuration = 0.5f;
    [SerializeField] private float dashCooldown = 0.5f;
    [SerializeField] private float hitRecoveryDuration = 0.5f;
    [SerializeField] private UI_Inventory uiInventory; //Inventory stuff
    [SerializeField] private GameObject spritePlayer;
    [SerializeField] private GameObject spriteHands1;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    [SerializeField] private UI_CraftingSystem uiCraftingSystem; //Crafing system stuff
    private NpcController npc;


    private bool switchOrientation;
    public static event Action OnPlayerDamaged;

    public Animator playerAnimator;
    public bool isDashing;

    [SerializeField] private Vector2 movement;
    private PlayerControls playerControls;

    private Rigidbody2D rb;

    //Inventory stuff
    private InventoryManager inventory;

    //Player pos stuff
    private void Start()
    {
        activeMoveSpeed = moveSpeed;
        //Crafting system stuff
        CraftingSystem craftingSystem = new CraftingSystem();
        Item item = new Item { itemType = Item.ItemType.GhastTear, amount = 1 };
        //craftingSystem.SetItem(item, 1, 2);
        //Debug.Log(craftingSystem.GetItem(1, 2));

        uiCraftingSystem.SetCraftingSystem(craftingSystem); //Aqui
    }
    
    //Player pos stuff
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    
    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();

        inventory = new InventoryManager(UseItem); //Inventory stuff
        uiInventory.SetPlayer(this); //Drop item stuff
        uiInventory.SetInventory(inventory); //Inventory stuff

        //Anadir los items en el suelo (usar el editor)
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

private void UseItem(Item item)
    {
        switch (item.itemType)
        {
            case Item.ItemType.GhastTear:
                inventory.RemoveItem(new Item { itemType = Item.ItemType.GhastTear, amount = 1 });
                break;
            
            case Item.ItemType.SpiderEye:
                inventory.RemoveItem(new Item { itemType = Item.ItemType.SpiderEye, amount = 1 });
                break;
            
            case Item.ItemType.Crystal:
                inventory.RemoveItem(new Item { itemType = Item.ItemType.Crystal, amount = 1 });
                break;
            
            case Item.ItemType.ShadowHorn:
                inventory.RemoveItem(new Item { itemType = Item.ItemType.ShadowHorn, amount = 1 });
                break;
        }
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        if (!inDialogue()&& GameManager.instance.playerCanMove) { 
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
            ChangeOrientation(movement.x);
        }
    }

    private void FixedUpdate()
    {
        if (!inDialogue() && GameManager.instance.playerCanMove)
        {
            if (isDashing)
            {
                return;
            }
            Move();
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
    }
    private void Move()
    {
        rb.MovePosition(rb.position + movement * (activeMoveSpeed * Time.fixedDeltaTime));
        if(movement != Vector2.zero)
        {
            playerAnimator.SetBool("IsRunning",true);
        }
        else
        {
            playerAnimator.SetBool("IsRunning", false);
        }
    }

    private IEnumerator Roll()
    {
      
        GameManager.instance.playerCanAtack = false;
        playerAnimator.SetBool("IsRolling", true);
        print("RollingTrue!");
        isDashing = true;
        GameManager.instance.playerInvinsibility = true;
        rb.velocity = new Vector2(movement.x * dashMoveSpeed, movement.y * dashMoveSpeed);

        yield return new WaitForSeconds(dashDuration);
        GameManager.instance.playerInvinsibility = false;
        GameManager.instance.playerCanAtack = true;
        isDashing = false;
        playerAnimator.SetBool("IsRolling", false);
        print("RollingFalse!");
    }
    private IEnumerator HitRecovery()
    {
        System.Random random = new System.Random();
        int randomInt = random.Next(0, 2);
        print(randomInt);
        playerAnimator.SetBool("IsInvincible", true);
        GameManager.instance.playerIsHit = false;
        GameManager.instance.playerInvinsibility = true;
        GameManager.instance.playerHealth--;
        CameraShake.Instance.shakeCamera(5f, .2f);
        switch (randomInt)
        {
            case 0:
                AudioManager.instance.PlayFootSteps("PlayerHit1");
                break;
            case 1:
                AudioManager.instance.PlayFootSteps("PlayerHit2");
                break;
        }
        StartCoroutine(FadeAlpha());
         OnPlayerDamaged?.Invoke();
        yield return new WaitForSeconds(hitRecoveryDuration);
        GameManager.instance.playerInvinsibility = false;
        playerAnimator.SetBool("IsInvincible", false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Npc")
        {
            GameManager.instance.playerCanDialog = true;
            
            npc = collision.gameObject.GetComponent<NpcController>();
            
            if(Input.GetKey(KeyCode.E))
            {
                print("Watesigma");
                GameManager.instance.playerIsInDialog = true;
                GameManager.instance.playerCanMove = false;
                npc.ActiveDialog();
                
            }
        }
    }
    void ChangeOrientation(float inputMovement)
    {
        if ((switchOrientation == true && inputMovement > 0) || (switchOrientation == false && inputMovement < 0))
        {

            switchOrientation = !switchOrientation;
            spritePlayer.transform.localScale = new Vector2(-spritePlayer.transform.localScale.x, spritePlayer.transform.localScale.y);
            spriteHands1.transform.localScale = new Vector2(-spriteHands1.transform.localScale.x, spriteHands1.transform.localScale.y);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        npc = null;
        GameManager.instance.playerCanDialog = false;
    }
    private bool inDialogue()
    {
        if(npc!= null)
        {
            return npc.DialogActive();
        }
        else
        {
            return false;
        }
    }

    IEnumerator FadeAlpha()
    {
        // Set alpha to 0
        SetAlpha(0.0f);
        yield return new WaitForSeconds(2.0f); // Wait for 2 seconds

        // Set alpha back to 1
        SetAlpha(1.0f);
    }

    void SetAlpha(float alpha)
    {
        Color color = spriteRenderer.color;
        color.a = alpha;
        spriteRenderer.color = color;
    }

}
