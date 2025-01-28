using System;
using System.Collections;
using System.Collections.Generic;

using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoresList : MonoBehaviour
{
    public GameObject listItemBtnPrefab;
    GameManager.FileData scoresData;


    private void Start() {
        if(GameManager.Instance == null) return;

        scoresData = GameManager.Instance.LoadScoresFromFile();

        if(scoresData != null){
            foreach(var item in scoresData.scoreboard.OrderByDescending(dt => dt.Score))
            {
                GameObject listItem = Instantiate(listItemBtnPrefab, this.transform);
                listItem.GetComponentInChildren<Text>().text = $"{item.Name} : {item.Score}";
            }
        }
        else
        {
            GameObject listItem = Instantiate(listItemBtnPrefab, this.transform);
            listItem.GetComponentInChildren<Text>().text = $"No records found.";
        }
    }
}
