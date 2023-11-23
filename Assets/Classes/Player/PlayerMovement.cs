using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigidbody;
    BoxCollider2D collider; 
    PlayerStats playerStats;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck; 
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>(); 
        playerStats = GetComponent<PlayerStats>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();

        
    }

    public bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); 
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = new Vector2(playerStats.speed, rigidbody.velocity.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = new Vector2(-playerStats.speed, rigidbody.velocity.y);
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GroundCheck())
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, playerStats.jumpHeight);
        }
        if (Input.GetKeyUp(KeyCode.Space) && rigidbody.velocity.y > 0f)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y * 0.5f);
        }
    }
}
