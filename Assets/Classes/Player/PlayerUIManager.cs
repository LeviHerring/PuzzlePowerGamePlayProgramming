using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class PlayerUIManager : MonoBehaviour
{
    GameObject player; 
    PlayerStats playerStats;
    public Image xpBar; 
    
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
