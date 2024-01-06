using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpButtons : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HealthUp()
    {
        if(PlayerStats.Instance.statPoints > 0)
        {
            PlayerStats.Instance.maxHealth++;
            PlayerStats.Instance.statPoints--;
        }
        else
        {
            StartCoroutine(CantUseThatCoroutine()); 
        }
        
    }

    public void SpeedUp()
    {
        if (PlayerStats.Instance.statPoints > 0)
        {
            PlayerStats.Instance.speed++;
            PlayerStats.Instance.statPoints--;
        }
        else
        {
            StartCoroutine(CantUseThatCoroutine());
        }

    }

    public void AttackUp()
    {
        if (PlayerStats.Instance.statPoints > 0)
        {
            PlayerStats.Instance.attackStat++;
            PlayerStats.Instance.statPoints--;
        }
        else
        {
            StartCoroutine(CantUseThatCoroutine());
        }


    }

    public void BackToGameButton()
    {
        Time.timeScale = 1; 
        GetComponent<PlayerUIManager>().panels[6].SetActive(false); 

    }

    IEnumerator CantUseThatCoroutine()
    {
        GetComponent<PlayerUIManager>().panels[6].gameObject.GetComponent<LevelUpPanel>().cantUseThatText.SetActive(true);
        yield return new WaitForSeconds(2);
        GetComponent<PlayerUIManager>().panels[6].gameObject.GetComponent<LevelUpPanel>().cantUseThatText.SetActive(false);
    }
}
