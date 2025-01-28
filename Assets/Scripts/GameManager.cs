using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    [SerializeField] InputField playerNameInput;
    [SerializeField] Text playerBestScoreText;
    public static GameManager Instance;
    public PlayerData playerData;
    public Scores playerScores;

    private void Awake() {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    private void Start() {
        playerData = new PlayerData()
        {
            Name = playerNameInput.text.ToString(),
            BestScore = 0
        };

        // load player scores from file
        // LoadGameData();
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("main");
    }

    public void Exit()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }

    public class PlayerData
    {
        public string Name;
        public int BestScore;
    }

    public class Scores
    {
        public Dictionary<string, int> PlayerBestScores = new Dictionary<string, int>(10);
    }
}
