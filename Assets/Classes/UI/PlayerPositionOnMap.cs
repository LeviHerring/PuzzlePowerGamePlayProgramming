using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionOnMap : MonoBehaviour
{
    GameObject player;
    RectTransform rectTransform;
    public Vector3 offsetRight;
    public Vector3 offsetLeft;
    Vector3 offset; 
    //value 0 is the offset for left 
    //value 1 if the offset for down 
    //value 2 is the offset for right 
    //value 3 is up 
    public float[] values;  
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        player = PlayerStats.Instance.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > 330)
        {
            offset.x = values[2]; 
        }
        if(player.transform.position.x > 0 && player.transform.position.x < 20)
        {
            offset.x = values[0]; 
        }
        if (player.transform.position.x > 20 && player.transform.position.x < 40)
        {
            offset.x = -350;
        }
        if (player.transform.position.x > 40 && player.transform.position.x < 200)
        {
            offset.x = -250;
        }
        if (player.transform.position.x > 200 && player.transform.position.x < 330)
        {
            offset.x = -150;
        }
        if (player.transform.position.y < 0)
        {
            offset.y = values[1]; 
        }
        if(player.transform.position.y > 0 && player.transform.position.y < 100)
        {
            offset.y = -60; 
        }
        if(player.transform.position.y > 100)
        {
            offset.y = values[3];
        }

        rectTransform.localPosition = player.transform.position + offset;
    }
}
