using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienPatrol : MonoBehaviour
{
    public float speed = 1f;

    private Rigidbody2D _rigidbody;

    public float wallAware = 0.5f;
    public LayerMask groundLayer;

    // Movement
    private Vector2 _movement;
    private bool _facingRight;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        if (transform.localScale.x < 0f)
        {
            _facingRight = false;
        }
        else if (transform.localScale.x > 0f)
        {
            _facingRight = true;
        }
    }

    void Update()
    {
        Vector2 direction = Vector2.right;

        if (_facingRight == false)
        {
            direction = Vector2.left;
        }

        
        if (Physics2D.Raycast(transform.position, direction, wallAware, groundLayer))
        {
            Flip();
        }
        
    }

    private void FixedUpdate()
    {
        float horizontalVelocity = speed;

        if (_facingRight == false)
        {
            horizontalVelocity = horizontalVelocity * -1f;
        }

        _rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX * -1f;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
}
