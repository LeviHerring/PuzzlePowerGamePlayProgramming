using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPDrop : DroppedItems
{
    public override void Pickup()
    {
        Effect();
    }
    public void Effect()
    {
        amountGiven = Random.Range(1, (PlayerStats.Instance.maxXp - PlayerStats.Instance.xpAmount) - 1);
        PlayerStats.Instance.xpAmount += amountGiven;
        Destroy(gameObject);
    }
}
