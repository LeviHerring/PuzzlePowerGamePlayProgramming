using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManagement : MonoBehaviour
{
    ObstaclesScript obstacle; 
    public bool strengthUnlocked;
    public bool[] powersUnlocked; //Strength = 0, 
    bool canMove;
    PlayerStats stats;
    // Start is called before the first frame update
    void Start()
    { 
        stats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove && Input.GetKeyDown(KeyCode.K))
        {
            obstacle.coroutineNumber = 1;
        }
        //LevelChecker(); 

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag == "Moveable")
    //    {
    //        Debug.Log(true); 
    //        obstacle = collision.gameObject.GetComponent<ObstaclesScript>();
    //        Debug.Log(obstacle); 
    //        if (strengthUnlocked)
    //        {
               
    //            obstacle.coroutineNumber = 1; 
                
    //        }
    //    }
        
    //}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Moveable")
        {
            Debug.Log(true);
            obstacle = collision.gameObject.GetComponent<ObstaclesScript>();
            Debug.Log(obstacle);
            if (strengthUnlocked)
            {
                canMove = true; 
                

            }
        }
    }

    void LevelChecker()
    {
        switch (stats.xpLevel)
        {
            case 2:
                strengthUnlocked = true;
                powersUnlocked[0] = true; 
                break;
            case 5:
                powersUnlocked[1] = true;
                break;
            case 7:
                powersUnlocked[2] = true;
                break; 
        }
    }
}
