using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Input")]
    [SerializeField] private float speed=5f;
    [SerializeField] private float jump=8f;
    [SerializeField] private float jumpFall = 5f;
    [Header("Physics")]       
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private Weapon _weapon;
     
    private ShotPlayer _shotPlayer;
    private Vector2 playerMovement;
    private Controls playerInput;
    private Rigidbody2D rb;
    private bool isAttacking;
    private bool isJump;
    private bool isGrounded;
    private bool down;
    private int direction = 1;

    public bool isFacingRight = true;
    private void Awake()
    {
        playerInput = new Controls();
        rb = GetComponent<Rigidbody2D>();
        _shotPlayer = GetComponent<ShotPlayer>();
        
        playerInput.PlayerGame.Attack.started += Attack;
        playerInput.PlayerGame.Attack.canceled += FinishAttack;
        playerInput.PlayerGame.Move.started += context => ChangePlayerScale(context.ReadValue<Vector2>().x);

    }
    
    private void OnEnable()
    {
        playerInput.PlayerGame.Enable();
    }

    private void OnDisable()
    {
        playerInput.PlayerGame.Disable();
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
            }                                                               
            else if (playerInput.PlayerGame.Jump.WasReleasedThisFrame())
            {
                rb.velocity = new Vector2(rb.velocity.x, -jumpFall);
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

    private void ChangePlayerScale(float inputDirection)
    {
        if (inputDirection < 0)
        {
            direction = isFacingRight ? -1 : 1;
            isFacingRight = false;
        }
        else
        {
            direction = isFacingRight ? 1 : -1;
            isFacingRight = true;
        }
        transform.localScale = new Vector2(transform.localScale.x * direction, transform.localScale.y);
    }
        #endregion

    #region ATTACK
    private void Attack(InputAction.CallbackContext context)
    { 
        if(_weapon.canAttack == true)
        {
            isAttacking = true;
            _shotPlayer.Shot();
        } 
    }
    private void FinishAttack(InputAction.CallbackContext context)
    {
        isAttacking = false;
    }
    #endregion

    private void EnableGround()
    {
        
    }
}
