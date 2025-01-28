using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    public Text ScoreText;
    public Text BestScoreText;
    private GameManager gameManager;
    
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    
    void Update()
    {
        
    }

    public void UpdateScores(int m_Points)
    {
        if(gameManager != null){
            if(m_Points > gameManager.currentPlayerData.BestScore)
            {
                gameManager.currentPlayerData.BestScore = m_Points;
            }

            var bestPlayerScoreData = gameManager.PlayerWithBestScore;
            if(m_Points > bestPlayerScoreData.BestScore)
            {
                gameManager.SaveNewHighScore();
                BestScoreText.text = $"Best Score : {bestPlayerScoreData.Name} : {bestPlayerScoreData.BestScore}";
            }

            ScoreText.text = $"Score : {m_Points}";
        }
    }
}
