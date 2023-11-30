using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEditor.Search;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public Transform myTransform;
    public Transform newParent;
    GameObject player;
    public SpriteRenderer spriteRenderer;
    [SerializeField] public bool isEquipped;
    public string name; 
    
    // Start is called before the first frame update
    public void Start()
    {
        myTransform = GetComponent<Transform>(); 
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject; 
            Debug.Log("Collision"); 
            newParent = player.transform;

            myTransform.parent = newParent;
            
            StartCoroutine(FlickerAnimation());
            player.GetComponent<PlayerCombat>().hasWeapon = true;
            switch (name)
            {
                case "Sword":
                    player.GetComponent<PlayerCombat>().types = PlayerCombat.WeaponTypes.Sword;
                    break;
                case "Bustersword":
                    player.GetComponent<PlayerCombat>().types = PlayerCombat.WeaponTypes.Bustersword;
                    break; 
                case "Broadsword":
                    player.GetComponent<PlayerCombat>().types = PlayerCombat.WeaponTypes.Broadsword;
                    break;
                case "Othersword":
                    player.GetComponent<PlayerCombat>().types = PlayerCombat.WeaponTypes.OtherSword;
                    break;

            }
           
            isEquipped = true; 


        }
        if (gameObject.CompareTag("Weapon"))
        {
            if (collision.gameObject.CompareTag("Weapon"))
            {
                
                Debug.Log("Collided");
                if (isEquipped)
                {
                    if(gameObject.name == collision.gameObject.name)
                    {

                    }
                    else
                    {
                        Object.Destroy(gameObject);
                        
                    }
                    
                }
                if (!isEquipped)
                {
                    if (gameObject.name == collision.gameObject.name)
                    {
                        Object.Destroy(gameObject);
                    }
                }
                
            }

        }

    }


    public IEnumerator FlickerAnimation()
    {
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(0.25f);
        spriteRenderer.enabled = true;
    }
}
