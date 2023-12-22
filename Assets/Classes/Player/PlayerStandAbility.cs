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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canMove = true; 
    }

    // Update is called once per frame
    void Update()
    {
        hit = Physics2D.Raycast(raycastStartPoint.position, new Vector2(2, 0), 2f);
        StartCoroutine(StandPunch()); 
    }

    IEnumerator StandPunch()
    {
        if(canMove)
        {
            rb.velocity = new Vector2(3f, rb.velocity.y);
            yield return new WaitForSeconds(2f);
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
                Destroy(gameObject);
            }
        }    
        if(hit.collider == null)
        {
            Destroy(gameObject);
        }    
        

    }    
}
