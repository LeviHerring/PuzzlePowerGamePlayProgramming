using System.Collections;
using System.Collections.Generic;
using UnityEngine;



interface ITeleport
   {
   void Teleport(GameObject selfGameObject, Transform teleportEnd);
    IEnumerator TeleportingCountdown(); 
}
public class Teleporter : MonoBehaviour, ITeleport
{
    [SerializeField] bool isTeleportingEnemy; 
    [SerializeField] bool isTeleportingPlayer; 
    GameObject teleportedObject; 
    public Transform teleportEnd;
    bool isInTeleporter; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Teleport(GameObject selfGameObject, Transform teleportEnd)
    {
        selfGameObject.transform.position = teleportEnd.position; 
    }

    public IEnumerator TeleportingCountdown()
    {
        yield return new WaitForSeconds(1f); 
        if(isInTeleporter == true)
        {
            int countdown = 3;
            while(countdown>0)
            {
                countdown--;
                yield return new WaitForSeconds(1); 
            }
            if(countdown<= 0)
            {
                Teleport(teleportedObject, teleportEnd);
                isInTeleporter = false; 
            }
        }
        else
        {

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag.ToLower() == "player")
        {
            if(isTeleportingPlayer)
            {
                teleportedObject = collision.gameObject;
                isInTeleporter = true;
                StartCoroutine(TeleportingCountdown());
            }
          
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.ToLower() == "enemy")
        {
            if(isTeleportingEnemy)
            {
                teleportedObject = collision.gameObject;
                Teleport(teleportedObject, teleportEnd);
            }
           

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag.ToLower() == "player")
        {
            isInTeleporter = false; 
        }
    }



}

