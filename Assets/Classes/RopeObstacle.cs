using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeObstacle : MonoBehaviour
{
    public Interactables interactable;
    Rigidbody2D rb;
    float gravityStrength = -4f; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(interactable.isLeverOn == true)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            StartCoroutine(Gravity()); 
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }

        if(interactable.isOn == true)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            StartCoroutine(Gravity());
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }

    IEnumerator Gravity()
    {
        rb.velocity = new Vector2(rb.velocity.x, gravityStrength);
        yield return new WaitForSeconds(1f);
        rb.velocity = new Vector2(rb.velocity.x, 0f);
    }
}
