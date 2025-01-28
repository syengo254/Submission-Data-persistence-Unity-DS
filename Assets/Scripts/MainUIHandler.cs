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

        var bestPlayerScoreData = gameManager.PlayerWithBestScore;
        BestScoreText.text = $"Best Score : {bestPlayerScoreData.Name} : {bestPlayerScoreData.Score}";
    }

    
    void Update()
    {
        
    }

    public void UpdateScoresUI()
    {
        if(gameManager != null){
            var bestPlayerScoreData = gameManager.PlayerWithBestScore;

            BestScoreText.text = $"Best Score : {bestPlayerScoreData.Name} : {bestPlayerScoreData.Score}";
            ScoreText.text = $"Score : {gameManager.currentPlayerData.Score}";
        }
    }
}
