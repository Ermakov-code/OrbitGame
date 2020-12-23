using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class OrbitSteroid : MonoBehaviour
{

    public GameObject planet;

    public float radius = 0f;
    
    // public float rotationSpeed = 5f;
    //
    // public float runAwaySpeed = 0.33f;
    
    
    private void FixedUpdate()
    {

        // float t = Time.time;
        //
        //
        // //this.transform.position = this.transform.position + new Vector3((float)(a * (Math.Cos(t) / t)), (float)(a * (Math.Sin(t) / t)));
        //
        //
        //
        // float radius = runAwaySpeed * t;
        // float angle = rotationSpeed * t;
        //
        // float x = (float)Math.Cos(angle) * radius;
        // float y = (float)Math.Sin(angle) * radius;
        //
        // this.transform.position = this.transform.position + new Vector3(x, y);
        // this.transform.rotation = Quaternion.Euler(0 , (float)(-angle/Math.PI * 180), 0);
        
        
        

    }


    public Vector3 selectRandPos(float radius)
    {

        float angle = (float)(Random.Range(0, 360) * Math.PI * 2);

        return new Vector3((float)(Math.Cos(angle) * radius),(float)(Math.Sin(angle) * radius));
    }


}
