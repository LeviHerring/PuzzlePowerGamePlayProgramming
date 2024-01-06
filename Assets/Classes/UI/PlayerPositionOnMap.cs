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
        if(player.transform.position.x > 200)
        {
            offset.x = values[3]; 
        }
        if(player.transform.position.x < 200)
        {
            offset.x = values[0]; 
        }
        if(player.transform.position.y < 0)
        {
            offset.y = values[1]; 
        }
        if(player.transform.position.y > 0)
        {
            offset.y = values[3]; 
        }

        rectTransform.localPosition = player.transform.position + offset;
    }
}
