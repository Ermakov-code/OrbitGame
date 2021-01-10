using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{


    public GameObject joystick;
    
    public float fireRate = 0.5f;
   
    public float fireSpeed = 10f;

    public float energy = 20f;
    
    private ObjectPooler _objectPooler;
    private float fireTimer = 0f;


    public HealthBar energyBar;
    void Start()
    {
       _objectPooler = ObjectPooler.Instance;
       energyBar.SetMaxHealth(energy);
       
    }

   
    void FixedUpdate()
    {
        fireTimer += Time.deltaTime;
            if (fireRate <= fireTimer)
            {
                fireTimer = 0;
                if (!joystick.activeSelf)
                {
                    energy -= 1;
                    energyBar.SetHealth(energy);
                    if (energy > 0)
                    {
                        Fire();
                    }
                }
                else
                {
                    if (energy <= 20)
                    {
                        energy += 2;
                    }
                    energyBar.SetHealth(energy);
                }
                Debug.Log(energy);
            }
    }

    private void Fire()
    {
        GameObject bullet =  _objectPooler.SpawnFromPool("Bullet", transform.position, 
            transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity =  transform.up * fireSpeed;
    }
}
