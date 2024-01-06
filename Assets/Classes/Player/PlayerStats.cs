using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private static PlayerStats instance;
    public static PlayerStats Instance { get => instance; }

    public int maxHealth;
    public int currentHealth;
    public float speed;
    public float jumpHeight;
    public int xpAmount;
    public int xpLevel;
    public int maxXp;
    public bool hasWeapon;
    public Transform checkpoint;
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
            
            xpLevel++;
            maxHealth++;
            DamageLevelUp();  
            xpAmount = 0;
            statPoints++; 
            maxXp += 5;
            LevelUpUI(); 
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

    void LevelUpUI()
    {
        PlayerUIManager.Instance.panels[6].SetActive(true);
        Time.timeScale = 0; 
    }
}
