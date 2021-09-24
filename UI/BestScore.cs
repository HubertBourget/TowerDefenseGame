using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScore : MonoBehaviour
{
    [SerializeField] TMP_Text bestScore;
    ScoreHandler scoreHandler;
    string bestScoreText = "All Time Highest Gold Score: ";

    int previousBestScore;

    void Awake() 
    {
        scoreHandler = FindObjectOfType<ScoreHandler>();
        previousBestScore = PlayerPrefs.GetInt("highscore");
    }
    void OnEnable() 
    {
        
        int actualScore = (int)scoreHandler.getScore();

        if(actualScore > previousBestScore)
        {
        bestScore.text = bestScoreText + actualScore.ToString();
        PlayerPrefs.SetInt("highscore", actualScore);
        }
        else
        {
            bestScore.text = bestScoreText + previousBestScore.ToString();
        }
        // the save can be accessed in regedit
    }
}
