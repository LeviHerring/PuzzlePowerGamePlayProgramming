using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    bool isActive; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf)
        {
            isActive = true;
        }
        else
        {
            isActive = false; 
        }
       ToggleMap();

    }

    public void ToggleMap()
    {
        if (isActive)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Time.timeScale = 1f; 
                gameObject.SetActive(false); 
            }
        }
    }
}
