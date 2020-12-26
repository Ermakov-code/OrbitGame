using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private float score = 0f;


    private void Start()
    {
        scoreText.text = "Score: " + score;
    }

    public void incScore(float score)
    {
        this.score += score;
        scoreText.text = "Score: " + this.score;
    }
    
}
