using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public float speed;
    public float jumpHeight;
    public int xpAmount;
    public int xpLevel;
    public int maxXp; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Experience(); 
    }


    void Experience()
    {
        if(xpAmount >= maxXp)
        {
            
            xpLevel++;
            xpAmount = 0; 
            maxXp += 5; 

        }
    }
}
