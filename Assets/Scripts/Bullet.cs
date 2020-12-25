using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObj
{
    public void OnObjectSpawn()
    {
        
    }

    public float damage = 1f;
    private ObjectPooler _objectPooler;
    private ParticleSystem _particleSystem;
    
    private void Start()
    {
        _objectPooler = ObjectPooler.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "EnemyShip(Clone)"){
            _objectPooler.ReturnToPool(gameObject);
            //Debug.Log(other.GetComponent<Osteroid>().health);
            other.GetComponent<Osteroid>().health -= damage;
            _particleSystem = transform.Find("Blow").GetComponent<ParticleSystem>();
            if (_particleSystem == null)
            {
                Debug.Log("Объект не найден");
            }
            _particleSystem.Play();

        }
    }
    
}
