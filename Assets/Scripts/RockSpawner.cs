using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class RockSpawner : MonoBehaviour
{
    
    private ObjectPooler _objectPooler;
    private float spawnTime = 0f;
    
    
    
    public float radius = 3f;
    public float spawnRate = 0.2f;
    private void Start()
    {
        _objectPooler = ObjectPooler.Instance;
    }


    private void FixedUpdate()
    {
        spawnTime += Time.deltaTime;
        if (spawnRate <= spawnTime)
        {
            GameObject rock = _objectPooler.SpawnFromPool("Rock", selectRandPos(radius), quaternion.identity);
            
            spawnTime = 0;
        }
    }


    public Vector3 selectRandPos(float radius)
    {
        float angle = (float)(Random.value * Math.PI * 2);
        return new Vector3((float)(Math.Cos(angle) * radius),(float)(Math.Sin(angle) * radius));
    }

}
