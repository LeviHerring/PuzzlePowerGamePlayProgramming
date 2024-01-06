using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get => instance; } 

    public GameObject playerObject; 
    PlayerStats player;
    PARENTENEMY[] enemies;
    [SerializeField] int levelMilestone = 0;
    public bool hasRun = false;
    // Start is called before the first frame update

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this; 
        }
    }
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
                int random = Random.Range(0, 2);
                enemy.health += random;
                enemy.maxHealth += random; 
                enemy.damageDealt += Random.Range(0, 2); ;
                enemy.xpValue += Random.Range(0,2);

            }
            hasRun = true; 
        }
       
    }
}
