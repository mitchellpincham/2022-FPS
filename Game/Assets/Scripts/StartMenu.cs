using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Button PlayButton;
    public Button SettingsButton;
    public Button QuitButton;

    public static int difficulty;

    void Awake() {
        //MainMenu();

        PlayButton = GameObject.Find("PlayButton").GetComponent<Button>();
        SettingsButton = GameObject.Find("SettingsButton").GetComponent<Button>();
        QuitButton = GameObject.Find("QuitButton").GetComponent<Button>();

        PlayButton.onClick.AddListener(StartGame);
        SettingsButton.onClick.AddListener(Settings);
        QuitButton.onClick.AddListener(QuitGame);
    }

    void Update() {
        /////////
    }

    void StartGame() {
        SceneManager.LoadScene("Level Select");
    }

    void Settings() {
        SceneManager.LoadScene("Settings");
    }

    void QuitGame() {
        Application.Quit();
    }
}
