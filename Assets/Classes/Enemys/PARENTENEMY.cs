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
    private void Start()
    {
        
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
