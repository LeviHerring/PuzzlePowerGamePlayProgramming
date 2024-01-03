using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStandAbility : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject punch;
    RaycastHit2D hit;
    public Transform raycastStartPoint;
    bool canMove = true;
    float speed = 3f;
    public Quaternion test; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(transform.rotation == test)
        {
            speed = -3f; 
        }
        else
        {
            speed = 3f; 
        }
        canMove = true; 
    }

    // Update is called once per frame
    void Update()
    {
        hit = Physics2D.Raycast(raycastStartPoint.position, new Vector2(2, 0), 0.5f);
        StartCoroutine(StandPunch()); 
    }

    IEnumerator StandPunch()
    {
        if(canMove)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        if(hit.collider == true)
        {
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                canMove = false;
                rb.velocity = new Vector2(0, 0);
                punch.SetActive(true);
                yield return new WaitForSeconds(1f);
                punch.SetActive(false);
                //Destroy(gameObject);
            }
        }
        yield return new WaitForSeconds(2f);
        Destroy(gameObject); 
        

    }    
}
