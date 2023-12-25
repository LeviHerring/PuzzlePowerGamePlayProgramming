using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    bool canShoot = true; 
    public GameObject bullet;
    public Transform bulletSpawnPos; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    { 
    }

    IEnumerator Shoot()
    {
        while(canShoot)
        {
            Instantiate(bullet, bulletSpawnPos.position, bulletSpawnPos.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(bullet, bulletSpawnPos.position, bulletSpawnPos.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(bullet, bulletSpawnPos.position, bulletSpawnPos.rotation);
            yield return new WaitForSeconds(5f);
        }
    
    }
}
