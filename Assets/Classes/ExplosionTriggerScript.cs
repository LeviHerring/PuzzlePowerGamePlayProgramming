using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplosionTriggerScript : MonoBehaviour
{
    Rigidbody2D playerRigidbody;
    Transform playerTransform;
    Vector2 xVelocity;
    Vector2 yVelocity;
    [SerializeField] float xHeight;
    [SerializeField] float yHeight;
    GameObject parent; 
    
    // Start is called before the first frame update
    void Start()
    {
        if(isActiveAndEnabled)
        {
            StartCoroutine(activeLength());
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.ToLower() == "player")
        {
            playerRigidbody = collision.GetComponent<Rigidbody2D>();
            playerTransform = collision.GetComponent<Transform>();
            if (playerTransform.position.x > transform.position.x)
            {
                xVelocity = new Vector2(xHeight, 0f); 
            }
            else if (playerTransform.position.x < transform.position.x)
            {
                xVelocity = new Vector2(-xHeight, 0f);
            }
            if (playerTransform.position.y > transform.position.y)
            {
                yVelocity = new Vector2(0f, yHeight);
            }
            else if (playerTransform.position.y < transform.position.y)
            {
                yVelocity = new Vector2(0f, -yHeight);
            }

            playerRigidbody.velocity = xVelocity + yVelocity; 
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy"); 
            collision.gameObject.GetComponent<PARENTENEMY>().health -= 5; 
        }
    }

    IEnumerator activeLength()
    {
        yield return new WaitForSeconds(3);
        parent = GetComponentInParent<BombItem>().gameObject;
        Destroy(parent); 
        //Destroy(gameObject); 
    }
}
