using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsUIHandler : MonoBehaviour
{
    [SerializeField] Button clearSettingsBtn;
    [SerializeField] Toggle musicToggle;

    private void Start() {
        clearSettingsBtn.onClick.AddListener(() => {
            GameManager.Instance.ClearSavedScores();
        });

        musicToggle.isOn = SettingsManager.Instance.musicOn;
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void HandleMusicToggle()
    {
        SettingsManager.Instance.musicOn = musicToggle.isOn;
        GameManager.Instance.ToggleMusic();
    }
}
