using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItems : MonoBehaviour
{
    public virtual void Pickup()
    {
        Effect(); 
    } 
    public int amountGiven; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.ToLower() == "player")
        {
            Pickup(); 
        }
    }

    void Effect()
    {

    }

}
