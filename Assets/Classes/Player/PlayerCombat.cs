using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject[] hitboxes;
    int hitboxNumber;
    public bool canAttack;
    public bool hasWeapon;
    public WeaponTypes types;
    // Start is called before the first frame update



    void Start()
    {
        
    }

    public enum WeaponTypes
    {
        Sword,
        Broadsword,
        Bustersword,
        OtherSword
    }

    // Update is called once per frame
    void Update()
    {
        Combat();    
    }

    public void Combat()
    {
        if(Input.GetKeyDown(KeyCode.P) && canAttack)
        {
            if(!hasWeapon)
            {
                hitboxNumber = 0;
                StartCoroutine(AttackCoroutine());
                StartCoroutine(Cooldown());
            }
            if (hasWeapon)
            {
                GameObject weapon = GetComponentInChildren<Weapons>().gameObject;
                weapon.GetComponent<Weapons>().Attack(); 
            }
          
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            if(!hasWeapon)
            {
                hitboxNumber = 1;
                StartCoroutine(AttackCoroutine());
                StartCoroutine(Cooldown());
            }
        
        }
    }


    IEnumerator AttackCoroutine()
    {
        canAttack = false;
        hitboxes[hitboxNumber].SetActive(true);
        yield return new WaitForSeconds(0.3f);
        hitboxes[hitboxNumber].SetActive(false);
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(0.5f);
        canAttack = true; 
    }
}
