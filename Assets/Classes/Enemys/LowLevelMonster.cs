using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowLevelMonster : PARENTENEMY
{
   
    // Start is called before the first frame update
    void Start()
    {
        PerimeterSet();
        Debug.Log(name + speed + health + damageDealt); 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PerimeterSet()
    {
        name = "Goblin";
        speed = 1f;
        health = 10;
        damageDealt = 1;
        xpValue = 1; 
    }    
}
