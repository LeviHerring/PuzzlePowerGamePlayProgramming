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
        if(hasTakenDamage == true)
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
                playerStats.currentHealth--;
                damageCooldown = -1;
                StartCoroutine(TookDamage()); 
                break;
            case "enemyhitbox":
                playerStats.currentHealth -= 5;
                damageCooldown = -1;
                StartCoroutine(TookDamage());
                break; 

        }
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
