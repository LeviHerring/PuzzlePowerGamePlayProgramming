using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : Pickups
{
    bool canAttack = true; 
    public int damage;
    [SerializeField] Vector3 attackPosition; 
    // Start is called before the first frame update
    //void Start()
    //{
    //    //myTransform = GetComponent<Transform>();
    //    //spriteRenderer = GetComponent<SpriteRenderer>();
    //}

    // Update is called once per frame
    void Update()
    {
        if (isEquipped)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
               
                transform.parent = null;
                isEquipped = false;
                StartCoroutine(DropCooldown()); 
            }
        }
    }

    public void Attack()
    {
        if(canAttack == true)
        {
            GetComponent<Collider2D>().enabled = true;
            transform.Rotate(new Vector3(0, 0, 90));
            transform.localPosition = attackPosition; 
            canAttack = false; 
            StartCoroutine(AttackCooldown()); 
        }
        else
        {
            return; 
        }
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(1f);
        transform.Rotate(new Vector3(0, 0, -90));
        transform.localPosition = newPosition; 
        GetComponent<Collider2D>().enabled = false;
        canAttack = true; 
    }

    IEnumerator DropCooldown()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<Collider2D>().enabled = true;
        newParent.gameObject.GetComponent<PlayerCombat>().hasWeapon = false;
    }


}
