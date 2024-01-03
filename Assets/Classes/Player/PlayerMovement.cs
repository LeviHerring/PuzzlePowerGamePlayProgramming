using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
 //Get component of things
    new Rigidbody2D rigidbody;
    new BoxCollider2D collider; 
    PlayerStats playerStats;
    PowerManagement powerManagement;
    SpriteRenderer spriteRenderer;

    //booleans and things used for movement
     bool isCharged; 
    bool isCharging;
    bool canUseSpecial = true; 
    [SerializeField] bool canDoubleJump;
    [SerializeField] bool isFacingRight;
    public bool isDisguised; 
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    public bool hasPutMaskOn;
    Transform mask;
    public bool canMove = true;
    public Transform firePoint;
    bool hasHacked = false;
    public bool IsOnLadder;
    public bool isMultipleChoice; 

    //GameObjects
    public GameObject mapPanel;
    public GameObject bomb;
    public GameObject drone;
    public GameObject dog;
    public GameObject starPlatinum;
    public GameObject bullet;
    public GameObject hackHitbox; 
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>(); 
        playerStats = GetComponent<PlayerStats>(); 
        powerManagement = GetComponent<PowerManagement>(); 
        spriteRenderer = GetComponent<SpriteRenderer>();
        canMove = true; 
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
        if(canMove)
        {
            if (Input.GetKey(KeyCode.D))
            {
                rigidbody.velocity = new Vector2(playerStats.speed, rigidbody.velocity.y);
                if(!isFacingRight)
                {
                    Flip();
                }
                
            }
            if (Input.GetKey(KeyCode.A))
            {
                rigidbody.velocity = new Vector2(-playerStats.speed, rigidbody.velocity.y);
                if(isFacingRight)
                {
                    Flip();
                }
                
            }

            if(IsOnLadder)
            {
                if(Input.GetKey(KeyCode.W))
                {
                    rigidbody.velocity = new Vector2(rigidbody.velocity.x, 2f);
                }
            }
        }
        
    }

    public void Jump()
    {
        if(canMove)
        {
            if (Input.GetKeyDown(KeyCode.Space) && GroundCheck())
            {
                if (isCharging == false)
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
            if (Input.GetKeyDown(KeyCode.Space) && !GroundCheck() && canDoubleJump)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, playerStats.jumpHeight / 2);
                canDoubleJump = false;

            }
            if (GroundCheck())
            {
                canDoubleJump = true;
            }
        }
       
        
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f); 
        
    }

    public void PowerControls()
    {
        if (powerManagement.canMove && Input.GetKeyDown(KeyCode.K))
        {
            if(isFacingRight)
            {
                powerManagement.obstacle.strength = 10;
                
            }
            else
            {
                powerManagement.obstacle.strength = -10;
                
            }
            powerManagement.obstacle.coroutineNumber = powerManagement.obstacle.obstacleNumberType;

        }

        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.S) && GroundCheck() && powerManagement.powersUnlocked[1] && isMultipleChoice == false)
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
        }
        

        if(Input.GetKeyDown(KeyCode.F))
        {
            if (powerManagement.powersUnlocked[2] && canUseSpecial == true)
            {
                if(isFacingRight == true)
                {
                    StartCoroutine(PhaseCoroutine(5));
                }
                if(isFacingRight == false)
                {
                    StartCoroutine(PhaseCoroutine(5));
                }
                
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

        if(Input.GetKeyDown(KeyCode.L))
        {
            if(powerManagement.powersUnlocked[5])
            {
                StartCoroutine(Hacking()); 
                
               
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

        if(Input.GetKeyDown(KeyCode.U) && powerManagement.itemsUnlocked[2] == true && canUseSpecial == true)
        {
            Instantiate(bomb, transform.position, Quaternion.identity);
            StartCoroutine(Cooldown()); 
        }

        if(Input.GetKey(KeyCode.M) && powerManagement.itemsUnlocked[1] == true && canUseSpecial == true )
        {
            isMultipleChoice = true; 
        //    if(Input.GetKey(KeyCode.W) && isMultipleChoice == true)
        //    {
        //        Instantiate(drone, transform.position, Quaternion.identity);
        //        isMultipleChoice = false; 
        //    }
        //    if(Input.GetKey(KeyCode.S) && isMultipleChoice == true)
        //    {
        //        Instantiate(dog, transform.position, Quaternion.identity);
        //        isMultipleChoice = true; 
        //    }
            
        //    StartCoroutine(Cooldown());
        }

        if(isMultipleChoice == true && canMove == true)
        {
            if (Input.GetKey(KeyCode.W) && isMultipleChoice == true)
            {
                Instantiate(drone, transform.position, Quaternion.identity);
                isMultipleChoice = false;               
            }
            if (Input.GetKey(KeyCode.S) && isMultipleChoice == true)
            {
                Instantiate(dog, transform.position, Quaternion.Euler(new Vector3(0, 0, 89.31f)));
                isMultipleChoice = false;
            }
            StartCoroutine(Cooldown());
        }
        if (Input.GetKeyDown(KeyCode.Period) && powerManagement.itemsUnlocked[3] == true)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
        if (Input.GetKeyDown(KeyCode.B) && powerManagement.itemsUnlocked[4] == true && canUseSpecial == true)
        {
            Instantiate(starPlatinum, transform.position, transform.rotation);
            StartCoroutine(Cooldown());
        }
        if(powerManagement.itemsUnlocked[5] == true)
        {
            gameObject.GetComponent<GauntletScript>().enabled = true;
            powerManagement.itemsUnlocked[5] = false;
        }
    }

    IEnumerator ChargeJump()
    {
            Debug.Log("Charging");
            yield return new WaitForSeconds(2);
        Debug.Log("Charged"); 
            isCharged = true; 
    }

    IEnumerator PhaseCoroutine(int moveAmount)
    {
        Debug.Log(moveAmount);
        canUseSpecial = false; 
        RaycastHit2D raycastHit = Physics2D.Raycast(firePoint.position, 10f * new Vector2(1, 1), 5f);
        if (raycastHit)
        {
            if (raycastHit.collider.tag.ToLower() == "canteleportthrough")
            {
                rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
                spriteRenderer.enabled = false;
                collider.enabled = false;
                yield return new WaitForSeconds(1f);
                transform.Translate(moveAmount, 0, 0);



                rigidbody.constraints = RigidbodyConstraints2D.None;
                rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
                spriteRenderer.enabled = true;
                collider.enabled = true;
            }
        }
        else
        {
           
        }
        StartCoroutine(Cooldown()); 
       
    }

    IEnumerator Hacking()
    {
        hackHitbox.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        hackHitbox.SetActive(false);
    }

    IEnumerator Cooldown()
    {
        canUseSpecial = false; 
        yield return new WaitForSeconds(2f);
        canUseSpecial = true; 
    }
}
