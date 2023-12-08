using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombItem : MonoBehaviour
{
    int countdown = 3;
    public GameObject[] explosions;
    SpriteRenderer spriteRenderer; 
    // Start is called before the first frame update
    void Start()
    {
        countdown = 3; 
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Countdown()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Countdown()
    {
        while(countdown > 0)
        {
            
            yield return new WaitForSeconds(2);
            countdown--;
        }
        if(countdown >= 0) 
        {
            explosion();
            spriteRenderer.enabled = false;
        }
        


    }

    void explosion()
    {
        foreach(GameObject expl in explosions)
        {
            expl.SetActive(true); 
        }
    }
}
