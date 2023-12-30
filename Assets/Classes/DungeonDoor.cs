using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonDoor : MonoBehaviour
{
    public GameObject[] enemies;
    public int amountDead;
    bool isActivated;
    Collider2D collider;
    public Transform raycastTransform; 

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(!isActivated)
        {
            GetComponent<SpriteRenderer>().enabled = false; 
            collider.enabled = false;
            RaycastHit2D raycastHit = Physics2D.Raycast(raycastTransform.position, 10f * new Vector2(1, 1), 5f);
            if(raycastHit)
            {
                if (raycastHit.collider.tag.ToLower() == "player")
                {
                    GetComponent<SpriteRenderer>().enabled = true;
                    collider.enabled = true;
                    isActivated = true;
                }
            }
            
        }
        if(isActivated)
        {
            EnemiesAliveChecker();
            //IsDeadFunctionChecker(); 
            if (amountDead == enemies.Length)
            {
                gameObject.SetActive(false);
            }
        }
        
        
    }


    void EnemiesAliveChecker()
    {
        foreach(GameObject enemy in enemies)
        {
            if(enemy.GetComponent<PARENTENEMY>().hasBeenChecked == false && enemy.GetComponent<PARENTENEMY>().isDead == true)
            {
                amountDead++;
                enemy.GetComponent<PARENTENEMY>().hasBeenChecked = true; 
            }
        }
       
    }

    //void IsDeadFunctionChecker()
    //{
    //    foreach (bool isDead in isDead)
    //    {
    //        if (isDead == true && enemies[0].GetComponent<PARENTENEMY>().hasBeenChecked == false)
    //        {
    //            amountDead++;
    //            enemies[0].GetComponent<PARENTENEMY>().hasBeenChecked = true; 
    //        }
    //        else
    //        {
    //            return;
    //        }
    //    }
    //}

}
