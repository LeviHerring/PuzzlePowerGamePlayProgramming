using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandHitboxes : Hitboxes
{
    // Start is called before the first frame update


    // Update is called once per frame

    public new void OnTriggerEnter2D(Collider2D collision)
    {

        switch (collision.gameObject.tag.ToLower())
        {
            case "enemy":
                Debug.Log("Collided");
                collision.gameObject.GetComponent<PARENTENEMY>().health -= damage;
                break;
            case "vulnerable":
                Debug.Log("Collided with vulnerable");
                //collision.gameObject.GetComponentInParent<PARENTENEMY>().health -= damage;
                break;
            case "invulnerable":
                collision.gameObject.GetComponent<PARENTENEMY>().health -= damage;
                break;
        }
    }
}
