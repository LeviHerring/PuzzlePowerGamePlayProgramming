using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesScript : MonoBehaviour
{
    public int obstacleNumberType; //this is the coroutine number so it can be called easily, 1 = shoving it, 2 = pushing heavy one 3 = breaking/destroying
    public int strength; 
    public int coroutineNumber;
    new Rigidbody2D rigidbody;
    new Collider2D collider; 
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
       switch (coroutineNumber)
        {
            case 1:
                StartCoroutine(ObjectMove(strength));
                break;
            case 2:
                BigBoulderPush(); 
                break;
            case 3:
                DestroyBoulder(); 
                break; 
        } 
    }

    public IEnumerator ObjectMove(int strength)
    {
        Debug.Log("In coroutune for moving object"); 
        rigidbody.constraints = RigidbodyConstraints2D.None; 
        rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY; 
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation; 
        rigidbody.velocity = new Vector2(strength, 0);
        yield return new WaitForSecondsRealtime(1f);
        rigidbody.velocity = new Vector2(0, 0);
        rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
        coroutineNumber = 0; 
    }

    void BigBoulderPush()
    {
        rigidbody.constraints = RigidbodyConstraints2D.None;
        rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void DestroyBoulder()
    {
        rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        collider.enabled = false;
        GetComponent<SpriteRenderer>().enabled = false; 
    }
}
