using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableSpawner : EnemySpawner
{
    bool isHacked;
    [SerializeField] int timesHacked;
    public int health;
    [SerializeField] int originalTime; 


    new void Update()
    {
        StartCoroutine(SpawnerCoroutine());
        DeathCheck();
        HackedLevels(); 
        if(spawnerLevel > enemies.Length)
        {
            spawnerLevel = 0; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.ToLower() == "hitbox")
        {
            health--; 
        }
        if(collision.gameObject.name.ToLower() == "hackhitbox")
        {
            if(isHacked == false)
            {
                isHacked = true;  
            }
            if(isHacked == true)
            {
                timesHacked++; 
            }
            if(timesHacked > 4)
            {
               isHacked = false; 
               timesHacked = 0;
               
            }
            
        }
    }

    void DeathCheck()
    {
        if(health <= 0)
        {
            Destroy(gameObject); 
        }
    }




    void HackedLevels()
    {
        switch (timesHacked)
        {
            case 0:
                time = originalTime; 
              
                break;
            case 1:
                time = time*2;
            
                break;
            case 2:
                time = originalTime; 
                spawnerLevel++;
              
                break;
            case 3:
                time /= 2;
              
                break;
        }
    }
}
