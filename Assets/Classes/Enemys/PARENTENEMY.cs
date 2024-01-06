using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PARENTENEMY : MonoBehaviour
{
    public bool hasBeenChecked; 
    public bool isDead; 
    public int health;
    public int maxHealth; 
    public string enemyName;
    public int damageDealt;
    public float speed;
    public int xpValue;
    public GameObject xp;
    public areaFrom area;
    public GameObject[] drops; 

    public enum areaFrom
    {
        Start,
        Strength,
        HighJump,
        Phase,
        Disguise,
        Hacking,
        FinalLevel

    }
    private void Start()
    {
        switch(area)
        {
            case areaFrom.Strength:
                health += 3;
                maxHealth += 3;
                damageDealt += 1;
                xpValue += 1; 
                break;
            case areaFrom.HighJump:
                health += 4;
                maxHealth += 4;
                damageDealt += 1;
                xpValue += 1; 
                break;
            case areaFrom.Phase:
                health *= 2;
                maxHealth *= 2;
                damageDealt += 3;
                xpValue += 4;
                break;
            case areaFrom.Disguise:
                health += 8;
                maxHealth += 8;
                damageDealt += 3;
                xpValue += 4;
                break;
            case areaFrom.Hacking:
                health += 9;
                maxHealth += 9;
                damageDealt += 4;
                xpValue += 5;
                break;
            case areaFrom.FinalLevel:
                health *= 4;
                maxHealth *= 4;
                damageDealt += 10;
                xpValue += 10;
                break; 


        }
    }

    private void Update()
    {
        if(health <= 0)
        {
            if(isDead == false)
            {
                OnDeath();
            }
            
        }
    }

    void OnDeath()
    {
        int randomDrop = Random.Range(0, 15); 
        int randomXpAmount = Random.Range(0, xpValue);
        Debug.Log(randomXpAmount);
        switch (randomDrop)
        {
            case 1:
                Instantiate(drops[randomDrop-1], transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(drops[randomDrop - 1], transform.position, Quaternion.identity);
                break;
        }
        if(randomXpAmount > 0)
        {
            for(int x =0; x < randomXpAmount; x++)
            {
                Vector3 randomPos = Random.insideUnitCircle * 1f;
                randomPos += transform.position; 
                Instantiate(xp, randomPos, Quaternion.identity); 
            }
        }
        isDead = true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(Respawn()); 
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(10f);
        health = maxHealth;
        GetComponent<Collider2D>().enabled = true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<SpriteRenderer>().enabled = true;
        isDead = false; 
    }


}
