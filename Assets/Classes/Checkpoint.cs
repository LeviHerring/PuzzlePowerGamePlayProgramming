using System.Collections;
using System.Collections.Generic;
using UnityEngine;


interface Itrigger
{
    void OnTriggerEnter2D(Collider2D collision);
}
public class Checkpoint : MonoBehaviour, Itrigger
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.ToLower() == "player")
        {
            collision.gameObject.GetComponent<PlayerStats>().checkpoint = gameObject.transform; 
        }
    }
}
