using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 


public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter instance;
    int score = 0;
    public TMP_Text scoreText;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreText.text = "Score:" + score.ToString();
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = "Score:" + score.ToString();
    }
}
