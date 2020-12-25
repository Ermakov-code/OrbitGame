using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlanetRotation : MonoBehaviour
{

    public float rotationSpeed = 0.5f;
    void FixedUpdate()
    {
        transform.RotateAround(transform.position, new Vector3(Random.value, Random.value, 0), rotationSpeed);
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.name.Equals("Cube 2(Clone)"))
        {
            other.gameObject.SetActive(false);
        }

    }
}
