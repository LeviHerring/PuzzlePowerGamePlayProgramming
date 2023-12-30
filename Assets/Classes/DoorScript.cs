using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    bool isOn;
    public Interactables connectedInteractable;
    Collider2D doorCollider; 

    // Start is called before the first frame update
    void Start()
    {
        doorCollider = GetComponent<Collider2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(connectedInteractable.isOn || connectedInteractable.isLeverOn)
        {
            isOn = true;
        }
        else if(!connectedInteractable.isOn && !connectedInteractable.isLeverOn)
        {
            isOn = false;
        }

        if(isOn == true)
        {
            doorCollider.enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (isOn == false)
        {
            doorCollider.enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
