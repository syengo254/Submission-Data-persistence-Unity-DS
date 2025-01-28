using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsUIHandler : MonoBehaviour
{
    [SerializeField] Button clearSettingsBtn;

    private void Start() {
        clearSettingsBtn.onClick.AddListener(() => {
            GameManager.Instance.ClearSavedScores();
        });
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }
}
