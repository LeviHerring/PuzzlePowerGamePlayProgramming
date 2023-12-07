using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    bool hasBeenInteractedWith;
    bool isOn; 

    public enum InteractableTypes
    {
        Button, 
        Lever,
        PressurePlate
    } 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hasBeenInteractedWith)
        {
            if(Input.GetKeyDown(KeyCode.I))
            {
                 
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
}
