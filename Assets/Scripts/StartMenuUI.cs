using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartMenuUI : MonoBehaviour
{
    [SerializeField] Text playerBestScoreText;
    [SerializeField] InputField playerNameInput;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;
        
        if(gameManager.PlayerWithBestScore.Name.Length > 0)
        {
            playerBestScoreText.text = $"Best Score : {gameManager.PlayerWithBestScore.Name} : {gameManager.PlayerWithBestScore.Score}";
        }
    }

    public void SetPlayerName()
    {
        gameManager.currentPlayerData.Name = playerNameInput.text.ToString();
    }

    public void Exit()
    {
        gameManager.SaveNewHighScore();

        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }

    public void StartNewGame()
    {
        SetPlayerName();
        gameManager.GetSavedHighScore();
        SceneManager.LoadScene("main");
    }
    public void OpenSettings()
    {
        SceneManager.LoadScene(2);
    }

    public void OpenScoreboard()
    {
        SceneManager.LoadScene("ScoreboardScene");
    }
}
