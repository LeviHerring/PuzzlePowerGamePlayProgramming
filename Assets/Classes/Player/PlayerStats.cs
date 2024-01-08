using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    private static PlayerStats instance;
    public static PlayerStats Instance { get => instance; }

    GameObject canvas;
    public GameObject panel;
    TextMeshProUGUI[] text; 
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] int nextLevelUp;
    public bool isUnlockedCutseneOn;
    public bool isLevellingUp;

    public int maxHealth;
    public int currentHealth;
    public float speed;
    public float jumpHeight;
    public int xpAmount;
    public int xpLevel;
    public int maxXp;
    public bool hasWeapon;
    public Transform checkpoint;
    public Transform startingCheckpoint; 
    public int itemsUnlocked;
    public Hitboxes[] hitboxes;
    public int statPoints;
    public int attackStat; 

    // Start is called before the first frame update

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
    void Start()
    {
        transform.position = startingCheckpoint.position; 
        canvas = PlayerUIManager.Instance.gameObject;
        panel = PlayerUIManager.Instance.panels[8];
        text = panel.GetComponentsInChildren<TextMeshProUGUI>(); 
        foreach(TextMeshProUGUI t in text)
        {
            switch (t.gameObject.name.ToLower())
            {
                case "title":
                    titleText = t;
                    break;
                case "description":
                    descriptionText = t;
                    break; 
            }
        }
        nextLevelUp = 1; 

    }

    // Update is called once per frame
    void Update()
    {
        Experience();
        Death();
      
    }


    void Experience()
    {
        if(xpAmount >= maxXp)
        {
            isLevellingUp = true; 
            
            xpLevel++;
            maxHealth++;
            if(currentHealth < maxHealth)
            {
                currentHealth++; 
            }
            DamageLevelUp();  
            xpAmount = 0;
            statPoints++;
            attackStat++;
            UnlockedPower();
            if (isUnlockedCutseneOn == false)
            {
                LevelUpUI();
            }
            maxXp += 5;
            
          
           
        }
        if(xpAmount < maxXp)
        {
            isLevellingUp = false; 
        }


    }

    void Death()
    {
        if(currentHealth <= 0)
        {
            StartCoroutine(DeathCoroutine()); 
        }
    }

    IEnumerator DeathCoroutine()
    {
        bool hasRespawned = false;
        currentHealth = maxHealth;
        GetComponent<PlayerMovement>().canMove = false;
        yield return new WaitForSeconds(1f);
        if(hasRespawned == false)
        {
            GetComponent<PlayerMovement>().canMove = true;
           
            transform.position = checkpoint.position;
           
        }
        
       

    }

    void DamageLevelUp()
    {
        foreach(Hitboxes h in hitboxes)
        {
            h.damage++; 
        }
    }

    public void LevelUpUI()
    {
        PlayerUIManager.Instance.panels[6].SetActive(true);
        Time.timeScale = 0; 
    }

    void UnlockedPower()
    {
        if(xpLevel == nextLevelUp)
        {
            isUnlockedCutseneOn = true;
            switch (xpLevel)
            {
                case 1:
                    descriptionText.text = "Press K when you are touching big squares and you should be able to move them! \n If you put these rocks on pressure plates it'll help you solve puzzles!";
                    titleText.text = "You've unlocked Strength!";
                    panel.SetActive(true);
                    nextLevelUp = 3;
                  
                    break;

                case 3:
                    descriptionText.text = "Press down then the space bar you'll charge a jump, wait a couple of seconds and you should be able to jump to high places!";
                    titleText.text = "You've unlocked The Charing High Jump!";
                    panel.SetActive(true);
                    nextLevelUp = 6;
                    
                    break;
                case 6:
                    descriptionText.text = "Press F on walls with arrows through them and you should be able to go through them!";
                    titleText.text = "You've unlocked phase!";
                    panel.SetActive(true);
                    nextLevelUp = 8;
                 
                    break;
                case 8:
                    titleText.text = "You've unlocked the disguise!";
                    descriptionText.text = "Press G and you'll put on a mask, the enemies won't attack you if you wear a mask!";
                    panel.SetActive(true);
                    nextLevelUp = 11;
                  
                    break;
                case 11:
                    titleText.text = "You've unlocked the hacking ability!";
                    descriptionText.text = "Press L on some of the buttons and pressure plates and they will act different, like last for longer or only need to be pressed once!";
                    panel.SetActive(true);
                    nextLevelUp = 100;
                
                    break; 
            }
        }
    }


        
}
