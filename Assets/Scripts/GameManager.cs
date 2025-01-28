using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public AudioSource gameMusic;
    public PlayerData currentPlayerData;
    private PlayerData savedPlayerData;
    string saveFilePath;
    string scoresfilePath;
    bool highScoreChange = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            currentPlayerData = new PlayerData()
            {
                Name = "",
                Score = 0
            };
            saveFilePath = Path.Join(Application.persistentDataPath, "_playerScores.json");
            scoresfilePath = Path.Join(Application.persistentDataPath, "_allplayerscores.json");

            GetSavedHighScore();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCurrentScore(int score)
    {
        currentPlayerData.Score = score;
    }

    public void ToggleMusic()
    {
        gameMusic.mute = !SettingsManager.Instance.musicOn;
    }

    public void SaveNewHighScore()
    {
        if(!File.Exists(saveFilePath) || currentPlayerData.Score > savedPlayerData.Score)
        {
            savedPlayerData = new PlayerData()
            {
                Score = currentPlayerData.Score,
                Name = currentPlayerData.Name
            };
            highScoreChange = true;
            string data = JsonUtility.ToJson(savedPlayerData);
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
            savedPlayerData = new PlayerData()
            {
                Score = currentPlayerData.Score,
                Name = currentPlayerData.Name
            };
            highScoreChange = true;
        }
    }

    public void ClearSavedScores()
    {
        File.Delete(saveFilePath);
        File.Delete(scoresfilePath);
    }
    public PlayerData PlayerWithBestScore{
        get{
            return savedPlayerData;
        }
    }

    public FileData LoadScoresFromFile()
    {
        if(File.Exists(scoresfilePath)){
            string data = File.ReadAllText(scoresfilePath);
            return JsonUtility.FromJson<FileData>(data);
        }

        return null;
    }

    public void SaveScoresToFile()
    {
        if(!highScoreChange) return;

        highScoreChange = false;
        FileData data = new FileData();
        FileData fileData = LoadScoresFromFile();

        if(fileData != null)
        {
            foreach(var item in fileData.scoreboard)
            {
                data.scoreboard.Add(item);
            }
        }

        data.scoreboard.Add(PlayerWithBestScore);
        
        string serialData = JsonUtility.ToJson(data);
        File.WriteAllText(scoresfilePath, serialData);
    }

    [Serializable]
    public class FileData
    {
        public List<PlayerData> scoreboard = new ();
    }

    [Serializable]
    public class PlayerData
    {
        public string Name;
        public int Score;
    }
}
