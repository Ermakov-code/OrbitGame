using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    private ObjectPooler _objectPooler;
    public float fireRate = 0.5f;
    private float fireTimer = 0f;
    public float fireSpeed = 10f;
    void Start()
    {
       _objectPooler = ObjectPooler.Instance;
    }

   
    void FixedUpdate()
    {
        fireTimer += Time.deltaTime;
        if (fireRate <= fireTimer)
        {
            fireTimer = 0;
            Fire();
        }
    }

    private void Fire()
    {
        GameObject bullet =  _objectPooler.SpawnFromPool("Cube", transform.position, 
            transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity =  transform.up * fireSpeed;
    }
}
