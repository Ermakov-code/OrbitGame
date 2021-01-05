using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float score = 0f;

    public static ScoreCount Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        this.score = 0f;
        scoreText.text = "Score: " + score;
    }

    public void incScore(float score)
    {
        this.score += score;
        scoreText.text = "Score: " + this.score;
    }
    
}
