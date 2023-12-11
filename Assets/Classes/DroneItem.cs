using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class DroneItem : MonoBehaviour
{
    CameraFollow cameraFollow;
    GameObject player;
    Rigidbody2D rb;
    Collider2D col;
    GameObject panel;
    GameObject canvas;
    GameObject imageObject; 
    public Image metre; 
    float height = 0.5f;
    float speed = 3f;
    float timeLeftAlive = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        col = GetComponent<Collider2D>();
        canvas = GameObject.Find("UI Canvas");
        panel = canvas.GetComponent<PlayerUIManager>().panels[3]; 
        panel.SetActive(true);
        imageObject = GameObject.Find("FuelMetre");
        metre = imageObject.GetComponent<Image>();  
        cameraFollow = FindObjectOfType(typeof(CameraFollow)) as CameraFollow;
        player = cameraFollow.player; 
        cameraFollow.player = gameObject; 
        player.SetActive(false);
        timeLeftAlive = 10; 
    }

    // Update is called once per frame
    void Update()
    {
        Move(); 
        timeLeftAlive -= Time.deltaTime;
        metre.fillAmount = timeLeftAlive / 10; 
        if(timeLeftAlive <= 0)
        {
            DestroyDrone(); 
        }
    }

    void Move()
    {
        if(Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, height);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, -height);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 0)
        {
            DestroyDrone();  
        }
    }



    void DestroyDrone()
    {
        player.SetActive(true);
        cameraFollow.player = player;
        panel.SetActive(false); 
        Destroy(gameObject); 
    }
}
