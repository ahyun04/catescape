using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public Image hpGauge;
    public Text gameOverText;
    public Text timerText;
    
    public Button restartButton;


    private void Start()
    {
        gameOverText.gameObject.SetActive(false);  
        restartButton.gameObject.SetActive(false);
    }

    public void UpdateHpGauge(float fillAmount)
    {
        this.hpGauge.fillAmount = fillAmount;
    }
    public void UpdateTimer(float time)
    {
        timerText.text = $"Time: {Mathf.Ceil(time)}";
    }

    public void ShowGameOver(float score)
    {
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "GAME OVER";
        Time.timeScale = 0f;

        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
    }
}
