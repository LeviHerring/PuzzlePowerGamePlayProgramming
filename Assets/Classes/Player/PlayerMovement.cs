using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigidbody;
    BoxCollider2D collider; 
    PlayerStats playerStats;
    PowerManagement powerManagement;
    SpriteRenderer spriteRenderer; 
     bool isCharged; 
    bool isCharging;
    [SerializeField] bool canDoubleJump; 

    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck; 
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>(); 
        playerStats = GetComponent<PlayerStats>(); 
        powerManagement = GetComponent<PowerManagement>(); 
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        PowerControls(); 

        
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
            if(isCharging == false)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, playerStats.jumpHeight);
                canDoubleJump = true; 
            }
          
              
           
        }
        if (Input.GetKeyUp(KeyCode.Space) && rigidbody.velocity.y > 0f)
        {
            Debug.Log("Key is up"); 
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y * 0.5f);
            
        }
        if(Input.GetKeyDown(KeyCode.Space) && !GroundCheck() && canDoubleJump)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, playerStats.jumpHeight/2);
            canDoubleJump = false; 

        }
        if(GroundCheck())
        {
            canDoubleJump = true; 
        }
        
    }

    public void PowerControls()
    {
        if(Input.GetKeyDown (KeyCode.S)) 
        {
            isCharging = true; 
           
        }
        if (Input.GetKeyDown(KeyCode.Space) && isCharging == true)
        {
            if (powerManagement.powersUnlocked[1])
            {

                StartCoroutine(ChargeJump());

            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (isCharged)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, playerStats.jumpHeight * 1.3f);
                isCharged = false;
                isCharging = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            if (powerManagement.powersUnlocked[2])
            {
                StartCoroutine(PhaseCoroutine()); 
            }
        }
    }

    IEnumerator ChargeJump()
    {
            Debug.Log("Charging");
            yield return new WaitForSeconds(2);
        Debug.Log("Charged"); 
            isCharged = true; 
    }

    IEnumerator PhaseCoroutine()
    {
        rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        spriteRenderer.enabled = false;
        collider.enabled = false;
        yield return new WaitForSeconds(1f);
        transform.Translate(5, 0, 0);
        rigidbody.constraints = RigidbodyConstraints2D.None;
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation; 
        spriteRenderer.enabled = true;
        collider.enabled = true;
    }
}
