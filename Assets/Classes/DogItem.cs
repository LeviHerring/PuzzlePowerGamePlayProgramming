using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogItem : DroneAndDogParent
{
    public Transform groundCheck;
    public LayerMask groundLayer;
    bool canMove;
    public GameObject hitbox;
    bool canAttack = true;
    bool isFacingRight;
    

    // Update is called once per frame
    void Update()
    {
        Move();
        Combat(); 
        timeLeftAlive -= Time.deltaTime;
        metre.fillAmount = timeLeftAlive / 10;
        if (timeLeftAlive <= 0)
        {
            DestroyDrone();
        }
    }

    void Move()
    {
        if(Input.GetKey(KeyCode.A) && canMove)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            isFacingRight = false;
            Flip(-1); 
        }
        if(Input.GetKey(KeyCode.D) && canMove)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            isFacingRight = true;
            Flip(1);
        }
        if(Input.GetKeyDown(KeyCode.Space) && GroundCheck())
        {
            canMove = false;
            rb.velocity = new Vector2(rb.velocity.x, height); 
        }
        if(GroundCheck())
        {
            canMove = true; 
        }
        else if(!GroundCheck())
        {
            canMove = false;
        }
    }

    public bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void Combat()
    {
        if(Input.GetKeyDown(KeyCode.P) && canAttack)
        {
            StartCoroutine(CombatCoroutine()); 
        }
    }

    IEnumerator Cooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(1);
        canAttack = true;
    }

    IEnumerator CombatCoroutine()
    {
        canAttack = false;
        hitbox.SetActive(true);
        yield return new WaitForSeconds(1);
        hitbox.SetActive(false);
        StartCoroutine(Cooldown());
    }

    void Flip(float flipValue)
    {
        if (isFacingRight)
        {
            if(transform.localScale.y < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x, -1 * transform.localScale.y, 1);
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x, 1 * transform.localScale.y, 1);
            }
           
        }
        else
        {
            if(transform.localScale.y < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x, 1 * transform.localScale.y, 1);
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x, flipValue * transform.localScale.y, transform.localScale.z);
            }
          
        }

    }
}
