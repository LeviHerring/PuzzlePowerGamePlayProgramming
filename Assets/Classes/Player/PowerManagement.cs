using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManagement : MonoBehaviour
{
    ObstaclesScript obstacle; 
    public bool strengthUnlocked;
    public bool[] powersUnlocked = new bool[10]; //Strength = 0, 
    bool canMove;
    PlayerStats stats;
    public GameObject mask;
    bool hasInstanstiated;
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
        LevelChecker(); 

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
                //activates strength power 
                break;
            case 5:
                powersUnlocked[1] = true;
                //unlocks super mario bros 2/doki doki panic type charged jump 
                break;
            case 7:
                powersUnlocked[2] = true;
                //phase 
                break;
            case 10:
                powersUnlocked[3] = true;
                //activates 2 powers
                break;
            case 12:
                powersUnlocked[4] = true;
                InstanstiateMask(); 
                //activates disguise 
                break;
        }
    }

    void InstanstiateMask()
    {
        
        if(hasInstanstiated == false)
        {
            Instantiate(mask, this.transform);
            mask.transform.Find("Mask(Clone)");
            mask.gameObject.SetActive(false);
            hasInstanstiated = true;
        }
        else
        {
            return; 
        }
    }
}
