using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitSteroid : MonoBehaviour
{

    public GameObject planet;

    public float rotationSpeed = 5f;

    public float y = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    { 
        
        transform.GetComponent<Rigidbody>().velocity = Vector3.down;
        transform.RotateAround(planet.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        
    }
}
