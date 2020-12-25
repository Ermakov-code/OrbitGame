using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class OrbitSteroid : MonoBehaviour
{
    private ObjectPooler _objectPooler;
    private float spawnTime = 0f;
    
    
   

    public GameObject planet;
    public float radius = 3f;
    public float spawnRate = 0.2f;


    //private bool once = false;

   

    private void Start()
    {
        _objectPooler = ObjectPooler.Instance;
    }


    private void FixedUpdate()
    {
        spawnTime += Time.deltaTime;
        if (spawnRate <= spawnTime)
        {
            spawnTime = 0;

            int i = 0;
            
            GameObject osteroid =  _objectPooler.SpawnFromPool("Osteroid", transform.position + selectRandPos(radius), 
                transform.rotation);
            while (!osteroid && i != 10)
            {
                osteroid =  _objectPooler.SpawnFromPool("Osteroid", transform.position + selectRandPos(radius), 
                    transform.rotation);
                i++;
            }
        }
    }


    public Vector3 selectRandPos(float radius)
    {
        float angle = (float)(Random.value * Math.PI * 2);
        return new Vector3((float)(Math.Cos(angle) * radius),(float)(Math.Sin(angle) * radius));
    }


}
