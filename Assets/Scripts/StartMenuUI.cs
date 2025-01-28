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
        if(gameManager.gameStarted)
        {
            playerBestScoreText.gameObject.SetActive(true);
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
        gameManager.gameStarted = true;
        SceneManager.LoadScene("main");
    }

}
