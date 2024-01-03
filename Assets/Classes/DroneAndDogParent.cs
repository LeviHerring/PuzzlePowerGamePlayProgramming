using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneAndDogParent : MonoBehaviour
{
    public CameraFollow cameraFollow;
    public GameObject player;
    public Rigidbody2D rb;
    public Collider2D col;
    public GameObject panel;
    public GameObject canvas;
    public GameObject imageObject;
    public Image metre;
    public float height = 0.5f;
    public float speed = 3f;
    public float timeLeftAlive = 10f;
    // Start is called before the first frame update
    public void Start()
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
        player.GetComponent<SpriteRenderer>().enabled = false; 
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        player.GetComponent<Collider2D>().enabled = false; 
        timeLeftAlive = 10;
        player.GetComponent<PlayerMovement>().canMove = false;
        player.GetComponent<PlayerMovement>().isMultipleChoice = false;
    }


    public void DestroyDrone()
    {
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation; 
        player.GetComponent<Collider2D>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
        cameraFollow.player = player;
        panel.SetActive(false);
        player.GetComponent<PlayerMovement>().canMove = true; 
        Destroy(gameObject);
    }
   

    // Update is called once per frame
    //void Update()
    //{

    //}
}
