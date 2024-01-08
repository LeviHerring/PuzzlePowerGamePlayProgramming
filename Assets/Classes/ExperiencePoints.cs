using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperiencePoints : MonoBehaviour
{
    GameObject player; 
    PlayerStats playerStats; 
    public int experienceValue; 
    // Start is called before the first frame update
    void Start()
    {
        experienceValue = Random.Range(1, 7);
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
       if(player.gameObject.transform.position.x < gameObject.transform.position.x)
       {
            transform.Translate(-0.1f, 0, 0); 
       }
        if (player.gameObject.transform.position.x > gameObject.transform.position.x)
        {
            transform.Translate(0.1f, 0, 0);
        }

        if (player.gameObject.transform.position.y < gameObject.transform.position.y)
        {
            transform.Translate(0, -0.1f, 0);
        }
        if (player.gameObject.transform.position.y > gameObject.transform.position.y)
        {
            transform.Translate(0, 0.1f, 0);
        }

       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerStats = collision.GetComponent<PlayerStats>();
            playerStats.xpAmount += experienceValue; 
            Destroy(gameObject); 
        }
    }
}
