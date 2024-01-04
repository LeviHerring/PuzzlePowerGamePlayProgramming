using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class EnemyMove : MonoBehaviour
{
    PARENTENEMY enemyScript;
    new Rigidbody2D rigidbody;
    new Collider2D collider;
    bool move = true;
    bool isFacingRight = true; 
    Vector3 pointA;
    Vector3 pointB;
    RaycastHit2D hit;
    Ray ray;
    GameObject player; 
    [SerializeField] Transform rayCastLeftTransform;
    [SerializeField] Transform rayCastRightTransform;
    Vector2 wingedBatVector = new Vector2(3f, 0f);
    Vector3 batPointA;
    Vector3 batPointB;
    public GameObject punchHitbox;
    [SerializeField] Vector3 raycastLength; 
    // Start is called before the first frame update
    void Start()
    {
        move = true; 
        enemyScript = GetComponent<PARENTENEMY>();
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        pointA = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
        pointB = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);
        wingedBatVector = new Vector2(3f, rigidbody.velocity.y);
        batPointA = new Vector3(transform.position.x , transform.position.y + 2, transform.position.z);
        batPointB = new Vector3(transform.position.x , transform.position.y - 2, transform.position.z);
        
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
            case "gremlin":
                GremlinMove(); 
                break;
            case "wings":
                StartCoroutine(WingedGoblinMove());
                break;
            case "thompus":
                StartCoroutine(ThwompusMovement()); 
                break;
            case "staticpuncher":
                StartCoroutine(Punch());
                break;
            case "chasepuncher":
                ChaserPuncher();
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


        RaycastHit2D rightHit = Physics2D.Raycast(rayCastRightTransform.position, new Vector2(100, 0) * new Vector2(1, 1), 100f);
        //Draws Raycast, always goes down for some reason? 
        //Debug.DrawRay(rayCastTransform.position, new Vector2(4,0) * new Vector2(1, 1), color: Color.red, 1f);
       yield return new WaitForSeconds(2f);
        hit = Physics2D.Raycast(rayCastLeftTransform.position, new Vector2(-100, 0), 100f);
        Debug.DrawRay(rayCastLeftTransform.position, new Vector2(-100, 0), color: Color.red, 0.5f);
        yield return new WaitForSeconds(2f); 
        if (hit.collider)
        {
            if(hit.collider.gameObject.name == "Player")
            {
                Debug.Log("Yahoo!");
                player = hit.collider.gameObject;
                if (player.gameObject.GetComponent<PlayerMovement>().hasPutMaskOn)
                {
                    yield break;
                }
                if (player.transform.position.x < transform.position.x)
                {
                    Debug.Log("Left");
                    rigidbody.velocity = new Vector2(-5, rigidbody.velocity.y);
                }
            }
         
        }
        if(rightHit.collider)
        {
            if(rightHit.collider.gameObject.name == "Player")
            {
                if(rightHit.collider.gameObject.GetComponent<PlayerMovement>().hasPutMaskOn)
                {
                    yield break; 
                }
                else
                {
                    if (rightHit.collider.gameObject.transform.position.x > transform.position.x)
                    {
                        rigidbody.velocity = new Vector2(5, rigidbody.velocity.y);
                        
                    }
                }
               
                
            }
        }
        else
        {
            player = null;
            //float time = Mathf.PingPong(Time.time * enemyScript.speed, 1f);
            // transform.position = Vector3.Lerp(pointA, pointB, time);
            yield return new WaitForSeconds(5f);
        }
       
        
        


    }

    public void GremlinMove()
    {
        rigidbody.velocity = new Vector2(enemyScript.speed, rigidbody.velocity.y);
        RaycastHit2D rightHit = Physics2D.Raycast(rayCastRightTransform.position, raycastLength * new Vector2(1, 1), 5f);
        if (rightHit)
        {
            if (rightHit.collider.tag == "Player")
            {

            }
            else
            {
                raycastLength *= -1;
                transform.Rotate(0f, 180f, 0f);
                enemyScript.speed *= -1; 
            }
        }

    }

    IEnumerator WingedGoblinMove()
    {
        RaycastHit2D rightHit = Physics2D.Raycast(rayCastRightTransform.position, raycastLength * new Vector2(1, 1), 5f);
        if(rightHit)
        {
            if(rightHit.collider.tag == "Player")
            {
                 
            }
            else
            {
                raycastLength *= -1;
                wingedBatVector *= -1;
                transform.Rotate(0f, 180f, 0f);
            }
        }
        rigidbody.velocity = wingedBatVector;
        float time = Mathf.PingPong(Time.time * enemyScript.speed, 1f);
        batPointA.x = (transform.position.x + 0.01f);
        batPointB.x = (transform.position.x + 0.01f);
        transform.position = Vector3.Lerp(batPointA, batPointB, time);
        rigidbody.velocity = wingedBatVector;
        yield return new WaitForSeconds(0.5f);

    }

    IEnumerator ThwompusMovement()
    {
        RaycastHit2D rightHit = Physics2D.Raycast(rayCastRightTransform.position, new Vector2(0, -10) * new Vector2(1, 1), 100f);
        RaycastHit2D leftHit = Physics2D.Raycast(rayCastLeftTransform.position, new Vector2(0, -10) * new Vector2(1, 1), 100f);
        if (rightHit.collider)
        {
            if (rightHit.collider.gameObject.name == "Player")
            {
                player = rightHit.collider.gameObject;
                if (player.gameObject.GetComponent<PlayerMovement>().hasPutMaskOn)
                {
                    yield break;
                }
                else
                {
                    rigidbody.constraints = RigidbodyConstraints2D.None;
                    rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
                    rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
                    rigidbody.velocity = new Vector2(rigidbody.velocity.x, -10f);
                    yield return new WaitForSeconds(3f);
                    rigidbody.velocity = new Vector2(rigidbody.velocity.x, 6f);
                    yield return new WaitForSeconds(3f);
                    rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0f);
                    rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
                    

                }
            }
        }
        if (leftHit.collider)
        {
            if (leftHit.collider.gameObject.name == "Player")
            {
                player = leftHit.collider.gameObject;
                if (player.gameObject.GetComponent<PlayerMovement>().hasPutMaskOn)
                {
                    yield break;
                }
                else
                {
                    rigidbody.constraints = RigidbodyConstraints2D.None;
                    rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
                    rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
                    rigidbody.velocity = new Vector2(rigidbody.velocity.x, -10f);
                    yield return new WaitForSeconds(3f);
                    rigidbody.velocity = new Vector2(rigidbody.velocity.x, 10f);
                    yield return new WaitForSeconds(3f);
                    rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0f);
                    rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
                    

                }
            }
        }

    }


    IEnumerator Punch()
    {
        if(IsPlayerNear())
        {
            if(!isFacingRight)
            {
                Flip(); 
            }
            yield return new WaitForSeconds(0.3f);
            punchHitbox.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            punchHitbox.SetActive(false);
            StartCoroutine(Cooldown(1)); 
        }

    }

     bool IsPlayerNear()
    {
        LayerMask mask = LayerMask.GetMask("Player");
        return Physics2D.OverlapCircle(rayCastRightTransform.position, 1f, mask);
    }



    IEnumerator Cooldown(int cooldownTown)
    {
        yield return new WaitForSeconds(cooldownTown); 
    }


    void ChaserPuncher()
    {
        RaycastHit2D rightHit = Physics2D.Raycast(rayCastRightTransform.position, raycastLength * new Vector2(1, 1), 5f);
        if (rightHit.collider)
        {
            if (rightHit.collider.gameObject.name == "Player")
            {
                player = rightHit.collider.gameObject;
                Debug.Log(player.transform.position.x - transform.position.x);
                if (player.transform.position.x < transform.position.x)
                {
                    Debug.Log("Left");
                    //rigidbody.velocity = new Vector2(-5, rigidbody.velocity.y);
                }
                else if (player.transform.position.x > transform.position.x)
                {
                    //rigidbody.velocity = new Vector2(5, rigidbody.velocity.y);
                }
                if(player.transform.position.x - transform.position.x < 2)
                {
                    Debug.Log("It is less!"); 
                    Debug.Log(player.transform.position.x - transform.position.x); 
                    StartCoroutine(ChaserPunch());
                    //rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
                    
                }
            }
        }
    }

    IEnumerator ChaserPunch()
    {
            yield return new WaitForSeconds(0.3f);
            punchHitbox.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            punchHitbox.SetActive(false);
            StartCoroutine(Cooldown(1));
    }


    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }



}
