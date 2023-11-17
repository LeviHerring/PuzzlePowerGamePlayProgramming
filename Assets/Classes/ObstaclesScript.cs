using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesScript : MonoBehaviour
{
    public int coroutineNumber; 
    Rigidbody2D rigidbody;
    Collider2D collider; 
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
                StartCoroutine(ObjectMove());
                break; 
        } 
    }

    public IEnumerator ObjectMove()
    {
        rigidbody.velocity = new Vector2(10, 0);
        yield return new WaitForSecondsRealtime(1f);
        rigidbody.velocity = new Vector2(0, 0);
        coroutineNumber = 0; 
    }
}
