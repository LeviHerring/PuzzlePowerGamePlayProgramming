using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class PlayerUIManager : MonoBehaviour
{
    private static PlayerUIManager instance;
    public static PlayerUIManager Instance { get => instance; }

    GameObject player; 
    PlayerStats playerStats;
    public Image xpBar;
    public GameObject[] panels;
    public bool isPaused;
    public bool canBePressed;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI xpText;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
        panels[7].SetActive(true);
        isPaused = true;
        canBePressed = true; 
        Time.timeScale = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        XpBarFill();
        SetText(); 
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = !isPaused;
                Time.timeScale = isPaused ? 0:1;
             
                panels[7].SetActive(isPaused);
              
            }

      
    }

    void XpBarFill()
    {
        float xpAmountFloat = playerStats.xpAmount;
        float maxXpFloat = playerStats.maxXp; 
        xpBar.fillAmount = (xpAmountFloat / maxXpFloat);
        //Debug.Log(xpBar.fillAmount); 
    }


    void SetText()
    {
        xpText.text = "Level " + playerStats.xpLevel.ToString() + " " + playerStats.xpAmount.ToString() + "/" + playerStats.maxXp.ToString();
        healthText.text = playerStats.currentHealth.ToString() + "/" + playerStats.maxHealth.ToString(); 
    }
}
