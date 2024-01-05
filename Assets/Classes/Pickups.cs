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
    new public string name;
    [SerializeField] public Vector3 newPosition; 
    
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
            if(player.GetComponent<PlayerCombat>().hasWeapon == true)
            {
                if(isEquipped == true)
                {
                    if (player.GetComponentInChildren<Pickups>().name == gameObject.name)
                    {
                        Object.Destroy(gameObject);
                    }
                    else
                    {
                        Destroy(player.GetComponentInChildren<Pickups>().gameObject);
                        isEquipped = true;
                        player.GetComponent<PlayerCombat>().hasWeapon = true;
                        myTransform.parent = newParent;
                        StartCoroutine(FlickerAnimation());
                    }
                }
              
                //checks what weapon player is holding and does stuff depending on that 

               
            }
            else
            {
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
                player.GetComponent<PlayerCombat>().hasWeapon = true;
                myTransform.parent = newParent;
                //transform.position = player.transform.position + new Vector3(0.5f, 1f, 0f);
                transform.localPosition = newPosition;
                transform.localRotation = Quaternion.Euler(0, 180, 0);
  
                

                StartCoroutine(FlickerAnimation());
            }
            
          


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
                        GetComponentInParent<PlayerCombat>().hasWeapon = false; 
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
        if(collision.gameObject.tag.ToLower() == "enemy" && gameObject.tag.ToLower() == "weapon" && isEquipped == true)
        {
            if(isEquipped)
            {
                collision.GetComponent<PARENTENEMY>().health -= GetComponent<Weapons>().damage; 
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
