using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    PlayerStats player;
    PARENTENEMY[] enemies;
    [SerializeField] int levelMilestone;
    bool hasRun = false; 
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerStats>(); 
    }

    // Update is called once per frame
    void Update()
    {
      levelMilestone = player.xpLevel; 
      switch (levelMilestone)
        {
            case 5:
                LevelUp(); 
                break;
            case 6:
                hasRun = false;
                break;
            case 10:
                LevelUp();
                break;
            case 11:
                hasRun = true;
                break; 
        }


      
    }

    void LevelUp()
    {
        enemies = FindObjectsOfType<PARENTENEMY>();
        if(hasRun == false)
        {
            foreach (var enemy in enemies)
            {
                enemy.health++;
                enemy.damageDealt++;
                enemy.xpValue++;

            }
            hasRun = true; 
        }
       
    }
}
