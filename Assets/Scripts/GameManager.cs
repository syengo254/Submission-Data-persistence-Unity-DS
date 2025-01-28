using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerData currentPlayerData;
    private PlayerData savedPlayerData;
    public bool gameStarted = false;
    string saveFilePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            currentPlayerData = new PlayerData()
            {
                Name = "",
                BestScore = 0
            };
            saveFilePath = Path.Join(Application.persistentDataPath, "_playerScores.json");

            GetSavedHighScore();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveNewHighScore()
    {
        if(!File.Exists(saveFilePath) || savedPlayerData.BestScore < currentPlayerData.BestScore)
        {
            string data = JsonUtility.ToJson(currentPlayerData);
            File.WriteAllText(saveFilePath, data);
        }
    }

    public void GetSavedHighScore()
    {
        if(File.Exists(saveFilePath))
        {
            string data = File.ReadAllText(saveFilePath);
            savedPlayerData = JsonUtility.FromJson<PlayerData>(data);
        }
        else
        {
            savedPlayerData = currentPlayerData;
        }
    }

    public PlayerData PlayerWithBestScore{
        get{
            return savedPlayerData;
        }
    }

    [Serializable]
    public class PlayerData
    {
        public string Name;
        public int BestScore;
    }
}
