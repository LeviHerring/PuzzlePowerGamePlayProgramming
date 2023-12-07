using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPuzzleItems : Pickups
{
    // Start is called before the first frame update
    GameObject player;
    public int itemNo; 

    // Update is called once per frame
    void Update()
    {
        
    }

    private new void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Worked"); 
            player = collision.gameObject; 
            newParent = player.transform;
            myTransform.parent = newParent;
            player.GetComponent<PowerManagement>().itemsUnlocked[itemNo] = true;    
            gameObject.SetActive(false); 

        }
    }
}
