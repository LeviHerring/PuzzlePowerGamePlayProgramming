using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    new Rigidbody2D rigidbody;
    new BoxCollider2D collider; 
    PlayerStats playerStats;
    PowerManagement powerManagement;
    SpriteRenderer spriteRenderer; 
     bool isCharged; 
    bool isCharging;
    [SerializeField] bool canDoubleJump;
    [SerializeField] bool isFacingRight;
    public bool isDisguised; 
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    public bool hasPutMaskOn;
    Transform mask;


    public GameObject mapPanel;
    public GameObject bomb;
    public GameObject Drone;
    public GameObject StarPlatinum; 
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
        ItemControls(); 

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
            isFacingRight = true;
            Flip(1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = new Vector2(-playerStats.speed, rigidbody.velocity.y);
            isFacingRight = false;
            Flip(-1); 
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
            //Debug.Log("Key is up"); 
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y * 0.5f);
            isCharged = false;
            isCharging = false;

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

    void Flip(float flipValue)
    {
        if (isFacingRight)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(flipValue, 1, 1);
        }
        
    }

    public void PowerControls()
    {
        if(Input.GetKeyDown (KeyCode.S) && GroundCheck() && powerManagement.powersUnlocked[1]) 
        {
            isCharging = true; 
           
        }
        if (Input.GetKeyDown(KeyCode.Space) && isCharging == true)
        {
                StartCoroutine(ChargeJump());
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

        if(Input.GetKeyDown(KeyCode.G))
        {
            if (powerManagement.powersUnlocked[4])
            {
                if(hasPutMaskOn == false)
                {
                    mask = gameObject.transform.Find("Mask(Clone)");
                    mask.gameObject.SetActive(true); 
                    hasPutMaskOn = true; 
                }
                else
                {
                    mask.gameObject.SetActive(false);
                    hasPutMaskOn = false; 
                }
                //disguise 
            }
        }
        
    }

    void ItemControls()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && powerManagement.itemsUnlocked[0] == true)
        {
            Debug.Log("Map");
            mapPanel.SetActive(true);
            Time.timeScale = 0f;  
            
        }
        else if(Input.GetKeyDown(KeyCode.Mouse0) && powerManagement.itemsUnlocked[0] == false)
        {
            Debug.Log("No Maps");
        }

        if(Input.GetKeyDown(KeyCode.U) && powerManagement.itemsUnlocked[2] == true)
        {
            Instantiate(bomb, transform.position, Quaternion.identity); 
        }

        if(Input.GetKeyDown(KeyCode.M) && powerManagement.itemsUnlocked[1] == true)
        {
            Instantiate(Drone, transform.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.B) && powerManagement.itemsUnlocked[4] == true)
        {
            Instantiate(StarPlatinum, transform.position, Quaternion.identity);
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
        if (isFacingRight)
        {
            transform.Translate(5, 0, 0);
        }
        else
        {
            transform.Translate(-5, 0, 0);
        }
       
        rigidbody.constraints = RigidbodyConstraints2D.None;
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation; 
        spriteRenderer.enabled = true;
        collider.enabled = true;
    }
}
