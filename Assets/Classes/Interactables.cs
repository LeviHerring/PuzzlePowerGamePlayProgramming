using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    bool hasBeenInteractedWith;
    public bool isOn;
    [SerializeField]public bool isLeverOn;
    public InteractableTypes type;
    public GameObject interactButton; 
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

            switch(type)
            {
                case InteractableTypes.Button:
                    if (Input.GetKeyDown(KeyCode.I))
                    {
                        StartCoroutine(Button());
                    }
                    break;
                case InteractableTypes.PressurePlate:
                    PressurePlate();
                    break;
                case InteractableTypes.Lever:
                    if (Input.GetKeyDown(KeyCode.I))
                    {
                        Lever();
                    }
                    break; 
            }
            interactButton.SetActive(true); 
        }
        PressurePlate(); 
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            hasBeenInteractedWith = true;
        }
       
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hasBeenInteractedWith = false;
        interactButton.SetActive(false);
    }

    IEnumerator Button()
    {
        Debug.Log("On");
        isOn = true;
        yield return new WaitForSeconds(2);
        isOn = false;
        Debug.Log("Off"); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(type == InteractableTypes.PressurePlate)
        {
            hasBeenInteractedWith = true; 
        }
    }

    void PressurePlate()
    {
        if(hasBeenInteractedWith == true)
        {
            isOn = true;
        }
        else
        {
            isOn = false;
        }
    }
    
    public void Lever()
    {
        if(!isLeverOn)
        {
            isLeverOn = true;
            
        }
        else
        {
            isLeverOn = false; 
        }
    }



    
}
