using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class OrbitRotate : MonoBehaviour
{
    public GameObject sphere;
    public float speed;
    public Joystick joystick;

    private Vector3 startPos;
    private void Start()
    {
        startPos = transform.forward;
    }

    void Update()
    {
        OrbitRotation();
    }
    
    private void OrbitRotation()
    {
        transform.RotateAround(sphere.transform.position, Vector3.forward,  -speed * Time.deltaTime * joystick.Horizontal);


        // if (joystick.Horizontal > 0)
        // {
        //     Vector3 newDir =
        //         Vector3.RotateTowards(transform.forward, new Vector3(45 * joystick.Horizontal, 0, 0), Time.deltaTime * speed/10, 0f);
        //     transform.rotation = Quaternion.LookRotation(newDir);
        // }
        //
        // if (joystick.Horizontal < 0)
        // {
        //     Vector3 newDir =
        //         Vector3.RotateTowards(transform.forward, new Vector3(45 * joystick.Horizontal, 0, 0), Time.deltaTime * speed/10, 0f);
        //     transform.rotation = Quaternion.LookRotation(newDir);
        //     
        // }
        //
        // if (joystick.Horizontal == 0)
        // {
        //     Vector3 newDir =
        //         Vector3.RotateTowards(transform.forward,startPos, Time.deltaTime * speed/10, 0f);
        //     transform.rotation = Quaternion.LookRotation(newDir);
        //     
        // }
        // transform.LookAt(sphere.transform.position);
        Debug.Log("Horizontal log: " + joystick.Horizontal);
    }
    
    private Tween SomeTween(float maxRadius, float expandTime, float rotateSpeed, float totalTime)
    {
        float radius = 0.0f;
        float angleDeg = 0.0f;
        return DOTween.Sequence()
            .Append(DOVirtual.Float(radius, maxRadius, expandTime, value => radius = value))
            .Join(DOVirtual.Float(angleDeg, rotateSpeed * totalTime, totalTime, value => angleDeg = value)
                .OnUpdate(() =>
                {
                    float angleRad = Mathf.Deg2Rad * angleDeg;
                    Vector3 xzOffset = radius * new Vector3(Mathf.Cos(angleRad), 0.0f, Mathf.Sin(angleRad));
                    Transform someTransform = null;
                    float someLocalY = 0.0f;
                    xzOffset.y = someLocalY;
                    someTransform.localPosition = xzOffset;
                }));
    }
}
