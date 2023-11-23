using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    PARENTENEMY enemyScript;
    Rigidbody2D rigidbody;
    Collider2D collider;
    bool move = true;
    Vector3 pointA;
    Vector3 pointB; 
    // Start is called before the first frame update
    void Start()
    {
        move = true; 
        enemyScript = GetComponent<PARENTENEMY>();
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        pointA = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
        pointB = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        MoveFunction();
    }

    void MoveFunction()
    {
        switch (enemyScript.enemyName.ToLower())
        {
            case "goblin":
                StartCoroutine(GoblinMoving()); 
               
                break; 
        }
    }

    IEnumerator GoblinMoving()
    {
        
        //        rigidbody.velocity = new Vector2(enemyScript.speed, rigidbody.velocity.y);
        //        yield return new WaitForSeconds(5f);
        //        rigidbody.velocity = new Vector2(-enemyScript.speed, rigidbody.velocity.y);
        //        yield return new WaitForSeconds(5f);
        float time = Mathf.PingPong(Time.time * enemyScript.speed, 1f);
        transform.position = Vector3.Lerp(pointA, pointB, time);
        yield return new WaitForSeconds(0.5f); 

    }
}
