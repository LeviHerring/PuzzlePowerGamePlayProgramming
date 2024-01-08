using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GauntletScript : MonoBehaviour
{
    bool hasActivatedGauntlet;
    bool isAttackActivated;
    bool isCountdownFinished;
    bool isLevitating;
    PlayerMovement playerMovement; 
    Rigidbody2D rb;
    [SerializeField] GameObject hitbox; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.J))
        {
            hasActivatedGauntlet = true; 
        }
        if(Input.GetKeyUp(KeyCode.J))
        {
            hasActivatedGauntlet = false; 
        }
        ActivatePower();
        LevitatingMovement(); 
    }

    void ActivatePower()
    {
        if(hasActivatedGauntlet)
        {
            if(Input.GetKeyDown(KeyCode.Keypad8) && hasActivatedGauntlet == true && isAttackActivated == false)
            {
                isAttackActivated = true;
                playerMovement.canMove = false; 
                Levitating(); 
                StartCoroutine(Countdown(10)); 
            }
            if (Input.GetKeyDown(KeyCode.Keypad2) && hasActivatedGauntlet == true && isAttackActivated == false)
            {
                isAttackActivated = true;
                playerMovement.canMove = false;
                StartCoroutine(SnapAttack()); 
                StartCoroutine(Countdown(2)); 
            }
        }
    }

    IEnumerator Countdown(int countdown)
    {
        isCountdownFinished = false;  
        while(countdown > 0)
        {
            countdown--;
            Debug.Log(countdown); 
            yield return new WaitForSeconds(1f);
        }
        ResetAllVariables(); 
        
    }

    void Levitating()
    {
        transform.Translate(new Vector3(0, 1f, 0));
        //rb.constraints = RigidbodyConstraints2D.FreezeAll;
        rb.gravityScale = 0f; 
        isLevitating = true; 
    }

    void LevitatingMovement()
    {
        if(isLevitating)
        {
            if(Input.GetKey(KeyCode.W))
            {
                transform.Translate(new Vector3(0, 0.1f, 0)); 
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(new Vector3(0, -0.1f, 0));
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(0.1f, 0, 0));
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector3(-0.1f, 0, 0));
            }
        }
    }

    void ResetAllVariables()
    {
        isAttackActivated = false;
        isCountdownFinished = true;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.gravityScale = 1f;
        isLevitating = false;
        playerMovement.canMove = true;
    }

    IEnumerator SnapAttack()
    {
        hitbox.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        hitbox.SetActive(false);
    }

}
