using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector2 PlayerMovement;
    private Controls playerInput;
    private Rigidbody2D rb;



    private void Awake()
    {
        playerInput = new Controls();
        rb = GetComponent<Rigidbody2D>();
       
        playerInput.PlayerGame.Move.performed += context =>
        {
            PlayerMovement = context.ReadValue<Vector2>();
            PlayerMove();
        };

        playerInput.PlayerGame.Attack.started += Attack;
    }

    private void Start()
    {
      
    }

    #region MOVEMENT
    private void PlayerMove()
    {
        rb.velocity = new Vector2(PlayerMovement.x * speed, rb.velocity.y);
    }

    #endregion

    private void Attack(InputAction.CallbackContext context)
    {

    }
    private void Update()
    {
       
    }

    private void FixedUpdate()
    {

    }

    private void OnEnable()
    {
        playerInput.PlayerGame.Enable();
    }

    private void OnDisable()
    {
        playerInput.PlayerGame.Disable();
    }

}
