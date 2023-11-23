using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject[] hitboxes;
    int hitboxNumber;
    public bool canAttack; 
    // Start is called before the first frame update
    void Start()
    {
        
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
            hitboxNumber = 0;
            StartCoroutine(AttackCoroutine());
            StartCoroutine(Cooldown());
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            hitboxNumber = 1;
            StartCoroutine(AttackCoroutine());
            StartCoroutine(Cooldown());
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
