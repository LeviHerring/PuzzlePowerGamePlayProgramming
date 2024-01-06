using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    bool isActive;
    public GameObject positionOnMap; 
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
            positionOnMap.SetActive(true); 
        }
        else
        {
            isActive = false;
            positionOnMap.SetActive(false);
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
                positionOnMap.SetActive(false);
            }
        }
    }
}
