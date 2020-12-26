using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlanetRotation : MonoBehaviour
{

    public float rotationSpeed = 0.5f;
    public float health = 10f;

    public TextMeshProUGUI healthText;

    private float startHealth;


    private void Start()
    {
        startHealth = health;
        healthText.text = health + "/" + startHealth;
        Debug.Log(health + "/" + startHealth);

    }

    void FixedUpdate()
    {
        transform.RotateAround(transform.position, new Vector3(Random.value * Time.deltaTime, Random.value * Time.deltaTime, 0), rotationSpeed);
    }


    private void OnTriggerEnter(Collider other)
    {

      

        if (other.name.Equals("EmenyBullet(Clone)"))
        {
            health -= 1;
            other.gameObject.SetActive(false);
        }
        
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }


        healthText.text = health + "/" + startHealth;
        Debug.Log(health + "/" + startHealth);
        

    }
}
