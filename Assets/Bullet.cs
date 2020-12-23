using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float damage = 1f;
    private ObjectPooler _objectPooler;
    private void Start()
    {
        _objectPooler = ObjectPooler.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Osteroid(Clone)"){
            _objectPooler.ReturnToPool(gameObject);
        }
        
    }
}
