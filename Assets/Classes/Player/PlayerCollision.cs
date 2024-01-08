using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    PlayerStats playerStats;
    float damageCooldown;
    bool hasTakenDamage;
    bool hasCalledCoroutine; 

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(hasTakenDamage == true || playerStats.currentHealth < playerStats.maxHealth)
        {
            damageCooldown += Time.deltaTime;
        }
        DamageCheck(); 
       
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag.ToLower())
        {
            case "enemy":
                playerStats.currentHealth -= collision.gameObject.GetComponent<PARENTENEMY>().damageDealt;
                damageCooldown = -1;
                StartCoroutine(TookDamage()); 
                break;
            case "enemyhitbox":
                Debug.Log("Collided with player"); 
                //playerStats.currentHealth -= collision.gameObject.GetComponentInParent<PARENTENEMY>().damageDealt + 2;
                damageCooldown = -1;
                StartCoroutine(TookDamage());
                break; 

        }

        switch(collision.gameObject.name.ToLower())
        {
            case "spiker":
                playerStats.currentHealth -= playerStats.currentHealth;
                break; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag.ToLower())
        {
            case "enemyhitbox":
                Debug.Log("Collided with player");
                playerStats.currentHealth -= collision.gameObject.GetComponentInParent<PARENTENEMY>().damageDealt + 2;
                damageCooldown = -1;
                StartCoroutine(TookDamage());
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch(collision.gameObject.tag.ToLower())
        {
            case "ladder":
                GetComponent<PlayerMovement>().IsOnLadder = true;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<PlayerMovement>().IsOnLadder = false;
    }

    void DamageCheck()
    {
        if(damageCooldown > 5 && playerStats.currentHealth < playerStats.maxHealth)
        {
            if(hasCalledCoroutine == false)
            {
                StartCoroutine(Healing());
                hasCalledCoroutine = true; 
            }
           
        }
    }

    IEnumerator TookDamage()
    {
        hasTakenDamage = true;
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator Healing()
    {
        while(damageCooldown > 5 && playerStats.currentHealth < playerStats.maxHealth)
        {
            playerStats.currentHealth++;
            yield return new WaitForSeconds(1f); 
        }
        hasTakenDamage = false;
        hasCalledCoroutine = false; 
    }
}
