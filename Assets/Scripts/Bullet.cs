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
            other.GetComponent<Osteroid>().health -= damage;
            _particleSystem = _objectPooler.SpawnFromPool("Particle", transform.position, transform.rotation).GetComponent<ParticleSystem>();
            _particleSystem.Play();
            _objectPooler.ReturnToPool(gameObject);
        }
    }
    
}
