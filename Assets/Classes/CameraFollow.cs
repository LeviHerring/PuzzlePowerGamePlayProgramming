using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IFreeCamera
{
    void Explore(); 
}
public class CameraFollow : MonoBehaviour, IFreeCamera
{
    float originalCameraSize; 
    [SerializeField] Camera playerCamera; 
    public GameObject player;
    [SerializeField] Vector3 offset;
    bool isFollowing; 
    // Start is called before the first frame update
    void Start()
    {
        originalCameraSize = playerCamera.orthographicSize; 
        playerCamera = GetComponent<Camera>(); 
        isFollowing = true; 
        player = GameObject.Find("Player");    
    }

    // Update is called once per frame
    void Update()
    {
        if(isFollowing == true)
        {
            transform.position = player.transform.position + offset;
        }
        Zoom();
        Explore();
        
       
    }

    void Zoom()
    {
        if(Input.GetKeyDown(KeyCode.Equals))
        {
            playerCamera.orthographicSize += 5; 
        }
        if(Input.GetKeyDown(KeyCode.Minus))
        {
            playerCamera.orthographicSize -= 5;
        }
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            playerCamera.orthographicSize = originalCameraSize; 
        }

        if(playerCamera.orthographicSize < 0)
        {
            playerCamera.orthographicSize = originalCameraSize;
        }
    }

    public void Explore()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            isFollowing = false;
            transform.Translate(new Vector3(-0.1f, 0, 0));
            player.GetComponent<PlayerMovement>().canMove = false; 

        }
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            isFollowing = true;
            player.GetComponent<PlayerMovement>().canMove = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            isFollowing = false;
            transform.Translate(new Vector3(0.1f, 0, 0));
            player.GetComponent<PlayerMovement>().canMove = false;

        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            isFollowing = true;
            player.GetComponent<PlayerMovement>().canMove = true;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            isFollowing = false;
            transform.Translate(new Vector3(0, 0.1f, 0));
            player.GetComponent<PlayerMovement>().canMove = false;

        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            isFollowing = true;
            player.GetComponent<PlayerMovement>().canMove = true;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            isFollowing = false;
            transform.Translate(new Vector3(0, -0.1f, 0));
            player.GetComponent<PlayerMovement>().canMove = false;

        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            isFollowing = true;
            player.GetComponent<PlayerMovement>().canMove = true;
        }
    }


}
