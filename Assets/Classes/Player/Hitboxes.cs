using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitboxes : MonoBehaviour
{
    public int damage;
    //PlayerStats player; 
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {

        switch (collision.gameObject.tag.ToLower())
        {
            case "enemy":
                Debug.Log("Collided");
                collision.gameObject.GetComponent<PARENTENEMY>().health -= PlayerStats.Instance.attackStat/2 + damage;
                break;
            case "vulnerable":
                Debug.Log("Collided with vulnerable"); 
                //collision.gameObject.GetComponentInParent<PARENTENEMY>().health -= damage;
                break;
            case "test":
                Debug.Log("Test");
                break; 
        }
    }




}
