using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableSpawner : EnemySpawner
{
    bool isHacked;
    [SerializeField] int timesHacked;
    public int health;


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
                time = 30; 
              
                break;
            case 1:
                time = 60;
            
                break;
            case 2:
                time = 30; 
                spawnerLevel++;
              
                break;
            case 3:
                time = 15;
              
                break;
        }
    }
}
