using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 

public class LevelUpPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] texts;
    public GameObject cantUseThatText;
    // Start is called before the first frame update
    void Start()
    {
        texts = GetComponentsInChildren<TextMeshProUGUI>(); 
    }

    // Update is called once per frame
    void Update()
    {
        SettingText(); 
    }

    void SettingText()
    {
        foreach(TextMeshProUGUI text in texts)
        {
            switch(text.gameObject.name.ToLower())
            {
                case "title text":
                    text.text = "Level up! You are now level " + PlayerStats.Instance.xpLevel.ToString();
                    break;
                case "statpoints":
                    text.text = "you have " + PlayerStats.Instance.statPoints.ToString() + " To use!";
                    break;
                case "attackbuttontext":
                    text.text = "+ 1 Attack " + "\n" + "You currently have " + PlayerStats.Instance.attackStat.ToString() + " attack";
                    break;
                case "speedbuttontext":
                    text.text = "+ 1 speed " + "\n" + "You currently have " + PlayerStats.Instance.speed.ToString() + " speed";
                    break;
                case "healthbuttontext":
                    text.text = "+ 1 health " + "\n" + "You currently have " + PlayerStats.Instance.maxHealth.ToString() + " Maximum Health";
                    break;
            }
        }
    }
}
