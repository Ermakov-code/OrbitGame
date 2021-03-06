﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private GameObject planet;
    [Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
        public AudioClip shot;
    }

    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    
    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }

    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (planet.activeInHierarchy)
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
                return null;
            }

            GameObject objectToSpawn = poolDictionary[tag].Dequeue();
            if (objectToSpawn.activeSelf && tag.Equals("Osteroid"))
            {
                poolDictionary[tag].Enqueue(objectToSpawn);
                return null;
            }

            objectToSpawn.SetActive(true);
            if (tag.Equals("Bullet"))
                AudioSource.PlayClipAtPoint(pools[0].shot, transform.position);
            else if (tag.Equals("EnemyBullet"))
                AudioSource.PlayClipAtPoint(pools[1].shot, transform.position);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            IPooledObj pooledObj = objectToSpawn.GetComponent<IPooledObj>();

            if (pooledObj != null)
            {
                pooledObj.OnObjectSpawn();
            }

            poolDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn;
        }
        return null;
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
    }


    public bool hasUnActiveObj(string tag)
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject obj = poolDictionary[tag].Dequeue();
            if (!obj.activeSelf)
            {
                poolDictionary[tag].Enqueue(obj);
                return true;
            }
            poolDictionary[tag].Enqueue(obj);
        }
        return false;
    }
}
