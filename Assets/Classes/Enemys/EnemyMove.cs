using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    PARENTENEMY enemyScript;
    Rigidbody2D rigidbody;
    Collider2D collider;
    bool move = true;
    Vector3 pointA;
    Vector3 pointB;
    RaycastHit2D hit;
    Ray ray;
    GameObject player; 
    [SerializeField] Transform rayCastTransform; 
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
            case "chasergoblin":
                StartCoroutine(ChaserGoblinMoving());
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

    IEnumerator ChaserGoblinMoving()
    {

        //        rigidbody.velocity = new Vector2(enemyScript.speed, rigidbody.velocity.y);
        //        yield return new WaitForSeconds(5f);
        //        rigidbody.velocity = new Vector2(-enemyScript.speed, rigidbody.velocity.y);
        //        yield return new WaitForSeconds(5f);



        RaycastHit2D hit = Physics2D.Raycast(rayCastTransform.position, new Vector2(4, 0) * new Vector2(1, 1), 1f);
        //Draws Raycast, always goes down for some reason? 
        Debug.DrawRay(rayCastTransform.position, new Vector2(4,0) * new Vector2(1, 1), color: Color.red, 1f);
        yield return new WaitForSeconds(2f);
        hit = Physics2D.Raycast(rayCastTransform.position, new Vector2(-4, 0) * new Vector2(1, 1), 1f);
        Debug.DrawRay(rayCastTransform.position, new Vector2(-4, 0) * new Vector2(1, 1), color: Color.red, 1f);
        yield return new WaitForSeconds(2f); 
        if (hit.collider.gameObject.name == "Player")
        {
            Debug.Log("Yahoo!");
            player = hit.collider.gameObject;
            if(player.transform.position.x > transform.position.x)
            {
                transform.Translate(0.1f, 0, 0);
            }
            if (player.transform.position.x < transform.position.x)
            {
                transform.Translate(-0.1f, 0, 0);
            }
        }
        else
        {
            //float time = Mathf.PingPong(Time.time * enemyScript.speed, 1f);
            // transform.position = Vector3.Lerp(pointA, pointB, time);
            yield return new WaitForSeconds(5f);
        }
       
        
        


    }

}
