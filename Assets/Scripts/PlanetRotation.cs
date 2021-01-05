using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlanetRotation : MonoBehaviour
{
    [SerializeField] private AudioClip osteriodSound;
    public float rotationSpeed = 0.5f;
    public float health = 10f;

    public TextMeshProUGUI healthText;

    
    private ObjectPooler _objectPooler;
    private ParticleSystem _particleSystem;
    private float startHealth;
    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        _objectPooler = ObjectPooler.Instance;
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

        if (other.gameObject.name == "asteroid2(Clone)")
        {
            health -= 3;
            
            _particleSystem = _objectPooler.SpawnFromPool("ParticleEnemy", other.transform.position, other.transform.rotation).GetComponent<ParticleSystem>();
            _particleSystem.Play();
            other.gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(osteriodSound, transform.position);
        }
        
        healthText.text = health + "/" + startHealth;
        Debug.Log(health + "/" + startHealth);

        if (health <= 0)
        {
            gameObject.SetActive(false);
            _gameManager.GameOver();
        }
    }
}
