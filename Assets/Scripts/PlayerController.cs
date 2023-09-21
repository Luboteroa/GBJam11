using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Input")]
    [SerializeField] private float speed=5f;
    [SerializeField] private float jump=8f;
    [SerializeField] private float jumpFall = 6f;
    [Header("Physics")]       
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius;
   
    private Vector2 playerMovement;
    private Controls playerInput;
    private Rigidbody2D rb;
    private bool isAttacking;
    private bool isJump;
    private bool isGrounded;
    private bool doubleJump;
    private bool down;

    private void Awake()
    {
        playerInput = new Controls();
        rb = GetComponent<Rigidbody2D>();
        
        playerInput.PlayerGame.Attack.started += Attack;
        playerInput.PlayerGame.Attack.canceled += FinishAttack;
        
        
    }
    
    private void OnEnable()
    {
        playerInput.PlayerGame.Enable();
    }

    private void OnDisable()
    {
        playerInput.PlayerGame.Disable();
    }

   
   
    private void FinishAttack(InputAction.CallbackContext obj)
    {
        isAttacking = false;
    }
    private void Update()
    {
       PlayerMove();
       Jump();
       isGrounded = IsGrounded();
    }

    private void FixedUpdate()
    {

    }

    #region JUMP
    private void Jump()
    {
            if (down ==true && playerInput.PlayerGame.Jump.WasPressedThisFrame() && isGrounded)
            {
                     Debug.Log("baja");
            }
            else if (playerInput.PlayerGame.Jump.WasPerformedThisFrame() && isGrounded && down == false)
            {
                
                rb.velocity = new Vector2(rb.velocity.x, jump);
                doubleJump = true;
            }         
            else if((playerInput.PlayerGame.Jump.WasPerformedThisFrame() && doubleJump == true))
            {
                rb.velocity = new Vector2(rb.velocity.x, jump);               
                doubleJump = false;
                playerInput.PlayerGame.Jump.Disable();
            }  
            else if (playerInput.PlayerGame.Jump.WasReleasedThisFrame())
            {
                rb.velocity = new Vector2(rb.velocity.x, -jumpFall);
            }
            else if(isGrounded)
            {
                playerInput.PlayerGame.Jump.Enable();            
            } 
            
    }
    private bool IsGrounded() => Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); 
    #endregion
   
    #region MOVEMENT
    private void PlayerMove()
    {
        playerMovement = playerInput.PlayerGame.Move.ReadValue<Vector2>();
        rb.velocity = new Vector2(playerMovement.x * speed, rb.velocity.y);
        if (playerMovement.y < 0)
        {
            down = true;
            EnableGround();
        }
        else
        {
            down = false;
        }
    }
    #endregion

    #region ATTACK
    private void Attack(InputAction.CallbackContext context)
    { 
        Debug.Log("Attack");
        isAttacking = true;
    }
    #endregion

    private void EnableGround()
    {
        
    }
}
