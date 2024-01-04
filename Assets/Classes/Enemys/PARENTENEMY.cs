using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PARENTENEMY : MonoBehaviour
{
    public bool hasBeenChecked; 
    public bool isDead; 
    public int health;
    public string enemyName;
    public int damageDealt;
    public float speed;
    public int xpValue;
    public GameObject xp;
    public areaFrom area; 

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
                damageDealt += 1;
                xpValue += 1; 
                break;
            case areaFrom.HighJump:
                health += 4;
                damageDealt += 1;
                xpValue += 1; 
                break;
            case areaFrom.Phase:
                health *= 2;
                damageDealt += 3;
                xpValue += 4;
                break;
            case areaFrom.Disguise:
                health += 8;
                damageDealt += 3;
                xpValue += 4;
                break;
            case areaFrom.Hacking:
                health += 9;
                damageDealt += 4;
                xpValue += 5;
                break;
            case areaFrom.FinalLevel:
                health *= 4;
                damageDealt += 10;
                xpValue += 10;
                break; 


        }
    }

    private void Update()
    {
        if(health <= 0)
        {
            OnDeath(); 
        }
    }

    void OnDeath()
    {
        int randomXpAmount = Random.Range(0, xpValue);
        Debug.Log(randomXpAmount);
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
        gameObject.SetActive(false);
    }


}
