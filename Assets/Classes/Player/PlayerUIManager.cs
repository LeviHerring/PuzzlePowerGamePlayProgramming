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
    }

    // Update is called once per frame
    void Update()
    {
        XpBarFill();  
    }

    void XpBarFill()
    {
        float xpAmountFloat = playerStats.xpAmount;
        float maxXpFloat = playerStats.maxXp; 
        xpBar.fillAmount = (xpAmountFloat / maxXpFloat);
        //Debug.Log(xpBar.fillAmount); 
    }    
}
