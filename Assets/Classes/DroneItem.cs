using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class DroneItem : DroneAndDogParent
{
    
    

    // Update is called once per frame
    void Update()
    {
        Move(); 
        timeLeftAlive -= Time.deltaTime;
        metre.fillAmount = timeLeftAlive / 10; 
        if(timeLeftAlive <= 0)
        {
            DestroyDrone(); 
        }
    }

    void Move()
    {
        if(Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, height);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, -height);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 0)
        {
            DestroyDrone();  
        }
    }



    
}
