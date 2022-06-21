using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Button playButton;
    public Button settingsButton;
    public Button quitButton;

    void Awake() {
        //MainMenu();

        playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        settingsButton = GameObject.Find("SettingsButton").GetComponent<Button>();
        quitButton = GameObject.Find("QuitButton").GetComponent<Button>();

        playButton.onClick.AddListener(StartGame);
        settingsButton.onClick.AddListener(Settings);
        quitButton.onClick.AddListener(QuitGame);
    }

    void Update() {
        /////////
    }

    void StartGame() {
        SceneManager.LoadScene("Level 01");
    }

    void Settings() {
        SceneManager.LoadScene("Settings");
    }

    void QuitGame() {
        Application.Quit();
    }
}
