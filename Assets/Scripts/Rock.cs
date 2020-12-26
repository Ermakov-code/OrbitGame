using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Rock : MonoBehaviour, IPooledObj
{
    
    public GameObject planet;
    public float rotationSpeed = 10f;

    public float startHealth = 5f;

    public float health;


    public ScoreCount scoreText;
    private ObjectPooler _objectPooler;
    private ParticleSystem _particleSystem;
    public void Start()
    {
        _objectPooler = ObjectPooler.Instance;
    }

    public void OnObjectSpawn()
    {
        health = startHealth;
        transform.DOMove(planet.transform.position, 10).SetEase(Ease.Linear);
    }

    private void FixedUpdate()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        if (_objectPooler == null)
            return;
        
        _particleSystem = _objectPooler.SpawnFromPool("ParticleEnemy", transform.position, transform.rotation)?.GetComponent<ParticleSystem>();
        _particleSystem.Play();
        scoreText.incScore(2f);
    }
} 
