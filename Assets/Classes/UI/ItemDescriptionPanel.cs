using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemDescriptionPanel : MonoBehaviour
{
    public GameObject canToggleOffText;
    bool canToggle;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Cutscene());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && canToggle == true)
        {
            Time.timeScale = 1.0f;
            canToggleOffText.SetActive(false);
            gameObject.SetActive(false);
            canToggle = false;
        }
    }

    IEnumerator Cutscene()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(3f);
        canToggleOffText.SetActive(true);
        canToggle = true;
    }
}
