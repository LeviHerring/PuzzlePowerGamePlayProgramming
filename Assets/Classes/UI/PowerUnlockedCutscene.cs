using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUnlockedCutscene : ItemDescriptionPanel
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    new void Update()
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(Cutscene());
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && canToggle == true)
        {
            Time.timeScale = 1.0f;
            canToggleOffText.SetActive(false);
            
            canToggle = false;
            
            PlayerStats.Instance.isUnlockedCutseneOn = false;
            Time.timeScale = 1.0f;
            gameObject.SetActive(false);
            PlayerStats.Instance.LevelUpUI();
        }
    }
}
