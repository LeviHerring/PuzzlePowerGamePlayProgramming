using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 10f; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(FireProjectile()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FireProjectile()
    {
        rb.velocity = transform.right * speed;
        yield return new WaitForSeconds(1);
        Destroy(gameObject); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.ToLower() == "enemy")
        {
            collision.gameObject.GetComponent<PARENTENEMY>().health -= 5;
            Destroy(gameObject);
        }
    }
}
