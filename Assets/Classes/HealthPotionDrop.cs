using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionDrop : DroppedItems
{
    public override void Pickup()
    {
        Effect();
    }

    public void Effect()
    {
        Debug.Log("In the health potion"); 
        if(PlayerStats.Instance.currentHealth < PlayerStats.Instance.maxHealth)
        {
            amountGiven = Random.Range(1, PlayerStats.Instance.maxHealth/2);
            PlayerStats.Instance.currentHealth += amountGiven;
            Destroy(gameObject);
        }
       
    }
}
