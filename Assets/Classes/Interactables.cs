using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 

public class Interactables : MonoBehaviour
{
    bool hasBeenInteractedWith;
    public bool isOn;
    [SerializeField]public bool isLeverOn;
    bool isHacked;
    [SerializeField] bool isPossibleToHack; 

    public InteractableTypes type;
    public GameObject interactButton;

    public GameObject SignCanvas;
    public string signName;
    public TextMeshProUGUI nameText;
    public string description;
    public TextMeshProUGUI descriptionText; 
    public enum InteractableTypes
    {
        Button, 
        Lever,
        PressurePlate,
        Sign,
        NewArea
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
                case InteractableTypes.Sign:
                    if(Input.GetKeyDown(KeyCode.I))
                    {
                        Sign(); 
                    }
                    break;
                case InteractableTypes.NewArea:
                    StartCoroutine(NewArea());
                    break;
            }
            interactButton.SetActive(true); 
        }
        if(type == InteractableTypes.PressurePlate)
        {
            PressurePlate();
        }
       
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
        if (isHacked == true)
        {
            yield return new WaitForSeconds(15);
        }
        else
        {
            yield return new WaitForSeconds(2);
            Debug.Log(2); 
        }
        
        isOn = false;
        Debug.Log("Off"); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(type == InteractableTypes.PressurePlate)
        {
            if(collision.gameObject.name.ToLower() == "hackhitbox")
            {
                
            }
            else
            {
                hasBeenInteractedWith = true;
            }
           
        }
        else if(type == InteractableTypes.Lever)
        {
            isOn = false; 
        }

        if(collision.gameObject.name.ToLower() == "hackhitbox")
        {
            if(isHacked == false)
            {
                if(isPossibleToHack == true)
                {
                    Debug.Log("Hacked"); 
                    isHacked = true;
                }
                return; 
            }
            if(isHacked == true)
            {
                isHacked = false; 
            }
        }

    }

    void PressurePlate()
    {
        if (hasBeenInteractedWith == true)
        {
            isOn = true;
        }
        else if (hasBeenInteractedWith == false && isHacked == false)
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

    void Hacked()
    {

    }

    void Sign()
    {
        if (!isOn)
        {
            isOn = true;
            nameText.text = signName;
            descriptionText.text = description; 
            SignCanvas.SetActive(true);
            Time.timeScale = 0; 

        }
        else
        {
            SignCanvas.SetActive(false);
            Time.timeScale = 1;
            isOn = false;
        }
    }

    IEnumerator NewArea()
    {
        SignCanvas.SetActive(true);
        nameText.text = signName;      
        descriptionText.text = description;
        yield return new WaitForSeconds(4f);
        SignCanvas.SetActive(false); 
    }
    
}
