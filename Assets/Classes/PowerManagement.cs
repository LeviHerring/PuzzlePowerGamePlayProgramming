using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManagement : MonoBehaviour
{
    ObstaclesScript obstacle; 
    public bool strengthUnlocked; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

                obstacle.coroutineNumber = 1;

            }
        }
    }
}
