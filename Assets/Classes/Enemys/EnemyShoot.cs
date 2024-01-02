using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    bool canShoot = true; 
    public GameObject bullet;
    public Transform bulletSpawnPos;
    public ShootingType shootingType; 
    // Start is called before the first frame update


    public enum ShootingType
    {
        Static, 
        MachineGun,
    }
    void Start()
    {
        switch (shootingType)
        {
            case ShootingType.Static:
                StartCoroutine(Shoot());
                break;
            case ShootingType.MachineGun:
                StartCoroutine(ShootMachineGun());
                break; 
        }
       
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

    IEnumerator ShootMachineGun()
    {
       for (int i = 0; i < 15; i++)
        {
            Instantiate(bullet, bulletSpawnPos.position, bulletSpawnPos.rotation);
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(7f); 

    }
}
