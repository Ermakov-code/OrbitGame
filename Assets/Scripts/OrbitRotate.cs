using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class OrbitRotate : MonoBehaviour
{
    public GameObject sphere;
    public float speed;
    public Joystick joystick;
    
    
    
    
    private Vector2 startPos;
    private Vector2 direction;
    
    
    
    private void Start()
    {
        startPos = transform.forward;
    }

    void Update()
    {
        
        
        //DrugOneFinger();
        
        OrbitRotation();
    }

    private void DrugOneFinger()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

          
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;
                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    Debug.Log(direction);
                    transform.RotateAround(sphere.transform.position, Vector3.forward,  -speed * Time.deltaTime * direction.magnitude);
                    break;
                case TouchPhase.Ended:
                    break;
            }
        }
    }


   
    
    private void OrbitRotation()
    {
        transform.RotateAround(sphere.transform.position, Vector3.forward,  -speed * Time.deltaTime * joystick.Horizontal);
        
    }
    
    // private Tween SomeTween(float maxRadius, float expandTime, float rotateSpeed, float totalTime)
    // {
    //     float radius = 0.0f;
    //     float angleDeg = 0.0f;
    //     return DOTween.Sequence()
    //         .Append(DOVirtual.Float(radius, maxRadius, expandTime, value => radius = value))
    //         .Join(DOVirtual.Float(angleDeg, rotateSpeed * totalTime, totalTime, value => angleDeg = value)
    //             .OnUpdate(() =>
    //             {
    //                 float angleRad = Mathf.Deg2Rad * angleDeg;
    //                 Vector3 xzOffset = radius * new Vector3(Mathf.Cos(angleRad), 0.0f, Mathf.Sin(angleRad));
    //                 Transform someTransform = null;
    //                 float someLocalY = 0.0f;
    //                 xzOffset.y = someLocalY;
    //                 someTransform.localPosition = xzOffset;
    //             }));
    // }
    
    
}
