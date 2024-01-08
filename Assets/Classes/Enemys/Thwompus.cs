using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thwompus : MonoBehaviour
{
    PARENTENEMY parentEnemy;
    Collider2D[] colliders; 
    // Start is called before the first frame update
    void Start()
    {
      parentEnemy = GetComponent<PARENTENEMY>();
        colliders = GetComponentsInChildren<Collider2D>(); 

    }

    // Update is called once per frame
    void Update()
    {
        if(parentEnemy.isDead == true)
        {
            foreach(Collider2D c in colliders)
            {
                c.enabled = false; 
            }
        }
        else
        {
            foreach (Collider2D c in colliders)
            {
                c.enabled = true;
            }
        }
    }
}
