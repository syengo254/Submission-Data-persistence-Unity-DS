using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMusic : MonoBehaviour
{
    private AudioSource cameraAudio;

    private void Awake() {
        cameraAudio = GetComponent<AudioSource>();
    }

    private void Update() {
        if(cameraAudio.mute == SettingsManager.Instance.musicOn)
        {
            cameraAudio.mute = !SettingsManager.Instance.musicOn;
        }
    }
}
