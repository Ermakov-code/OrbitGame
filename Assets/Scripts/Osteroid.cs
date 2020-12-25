using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Osteroid : MonoBehaviour, IPooledObj
{


    public float startHealth = 4f;

    public float size = 1f;
    
    public float bulletSpeed = 1f;
    
    public GameObject planet;

    private ObjectPooler _objectPooler;
    
    public float health;

    public void Start()
    {
        _objectPooler = ObjectPooler.Instance;
    }


    public void FixedUpdate()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void OnObjectSpawn()
    {


            health = startHealth;
        
            transform.DOLookAt(planet.transform.position, 0);
            Vector3 a = planet.transform.position - transform.position;
            Vector3 b = a.normalized;
            var c = a.magnitude * 0.4f;
            b *= c;


            transform.DOMove(planet.transform.position - b, 3).OnComplete(Fire);
            Debug.Log((planet.transform.position - transform.position).magnitude);


    }


    public void Fire()
    {
        if (gameObject.activeSelf)
        {
            GameObject emenyBullet = _objectPooler.SpawnFromPool("EnemyBullet", transform.position, transform.rotation);
            emenyBullet.transform.DOMove(planet.transform.position, bulletSpeed).onUpdate();
        }
    }
}
