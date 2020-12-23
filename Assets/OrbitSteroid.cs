using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitSteroid : MonoBehaviour
{

    public GameObject planet;

    public float rotationSpeed = 5f;

    public float runAwaySpeed = 0.33f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        float t = Time.time;

        float radius = runAwaySpeed * t;
        float angle = rotationSpeed * t;

        float x = (float)Math.Cos(angle) * radius;
        float y = (float)Math.Sin(angle) * radius;
        
        this.transform.position = new Vector3(x, y);
        this.transform.rotation = Quaternion.Euler(0 , (float)(-angle/Math.PI * 180), 0);

    }
}
