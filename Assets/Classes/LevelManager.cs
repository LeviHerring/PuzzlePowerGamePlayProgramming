using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject playerObject; 
    PlayerStats player;
    PARENTENEMY[] enemies;
    [SerializeField] int levelMilestone = 0;
    public bool hasRun = false; 
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerStats>();
        levelMilestone = 0; 
    }

    // Update is called once per frame
    void Update()
    {
      

           if(levelMilestone < player.xpLevel)
            {
            hasRun = false; 
              LevelUp(); 
            }
    


      
    }

    public void LevelUp()
    {
        levelMilestone++; 
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
