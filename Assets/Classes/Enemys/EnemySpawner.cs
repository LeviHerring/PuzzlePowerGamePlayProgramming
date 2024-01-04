using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public int spawnerLevel;
    public bool canSpawn = true;
    public int time = 30;
    int howManyToSpawn; 
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
                    howManyToSpawn = 3; 
                    SpawnFunction();
                    break;
                case 1:
                    howManyToSpawn = 1;
                    SpawnFunction();
                    break;
                case 2:
                    howManyToSpawn = 1;
                    SpawnFunction();
                    break;
                case 3:
                    howManyToSpawn = 3;
                    SpawnFunction();
                    break;
                case 4:
                    howManyToSpawn = 3;
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
            for(int x = 0; x < howManyToSpawn; x++)
            {
                Vector3 position;
                position.x = Random.Range(-3, 3);
                position.y = Random.Range(-3, 3);
                position.z = 0; 
                Instantiate(enemies[spawnerLevel], transform.position + position, Quaternion.identity);
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
