using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    float score =0;
    [SerializeField] float gameTimer = 0;
    void Update()
    {
        gameTimer =+ Time.deltaTime;

            score = gameTimer;

        
    }
    public float getScore()
    {
        return score;
    }
}
