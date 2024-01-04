using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemDescriptionPanel : MonoBehaviour
{
    LevelManager levelmanager; 
    public GameObject canToggleOffText;
    bool canToggle;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Cutscene());
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf)
        {
            StartCoroutine(Cutscene()); 
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && canToggle == true)
        {
            Time.timeScale = 1.0f;
            levelmanager = FindObjectOfType<LevelManager>();
            levelmanager.hasRun = false;
            levelmanager.LevelUp();
            canToggleOffText.SetActive(false);
            gameObject.SetActive(false);
            canToggle = false;
        }
    }

    public IEnumerator Cutscene()
    {
        Debug.Log("In cutscene coroutine"); 
        Time.timeScale = 0f;
        Debug.Log("Timescale is 0");
        yield return new WaitForSecondsRealtime(3f);
        canToggleOffText.SetActive(true);
        canToggle = true;
    }
}
