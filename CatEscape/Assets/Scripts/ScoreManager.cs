using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private float score = 0f;  
    private float scoreRate = 0f;
    public Text scoreText;
    private bool isGameOver = false;  

    void Update()
    {
        if (!isGameOver)
        {
            
            score += scoreRate * Time.deltaTime * 1000; 
        }
    }
    public void ShowGameScore(float score)
    {
        scoreText.gameObject.SetActive(true);
        scoreText.text = $"{score}";
        Time.timeScale = 0f;
    }
    public void StopScoring()
    {
        isGameOver = true;  
    }

    public float GetScore()
    {
        return Mathf.Min(score, 300f); 
    }

    public void ResetScore()
    {
        score = 0f; 
        isGameOver = false;  
    }
}
