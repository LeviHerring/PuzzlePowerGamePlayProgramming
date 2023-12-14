using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    public int spawnerLevel;
    bool canSpawn = true; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SpawnerCoroutine());
    }

    IEnumerator SpawnerCoroutine()
    {
        switch (spawnerLevel)
        {
            case 0:
                SpawnFunction(); 
                break;
        }

        yield return new WaitForSeconds(30);
        canSpawn = true;
    }

    void SpawnFunction()
    {
        if(canSpawn)
        {
            for(int x = 0; x < 3; x++)
            {
                Instantiate(enemies[spawnerLevel], transform.position, Quaternion.identity);
            }
            canSpawn = false; 
        }
    }
}
