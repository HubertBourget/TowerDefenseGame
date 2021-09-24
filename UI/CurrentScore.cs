using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentScore : MonoBehaviour
{
    [SerializeField] TMP_Text currentScore;
    ScoreHandler scoreHandler;
    string currentScoreText = "Highest Gold Score this time : ";
    void OnEnable() 
    {
        scoreHandler = FindObjectOfType<ScoreHandler>();
        currentScore.text = currentScoreText + scoreHandler.getScore();
    }
}
