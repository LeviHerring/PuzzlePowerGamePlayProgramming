using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public int spawnerLevel;
    public bool canSpawn = true;
    public int time = 30; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        StartCoroutine(SpawnerCoroutine());
    }

    public IEnumerator SpawnerCoroutine()
    {
        if(canSpawn == true)
        {
            switch (spawnerLevel)
            {
                case 0:
                    SpawnFunction();
                    break;
            }

        }
        yield return new WaitForSeconds(1); 
    }

    public void SpawnFunction()
    {
        if(canSpawn)
        {
            for(int x = 0; x < 3; x++)
            {
                Instantiate(enemies[spawnerLevel], transform.position, Quaternion.identity);
            }
            canSpawn = false;
            StartCoroutine(Cooldown(time)); 

        }
    }

    public IEnumerator Cooldown(int time)
    {
        yield return new WaitForSeconds(time);
        canSpawn = true; 
    }
}
