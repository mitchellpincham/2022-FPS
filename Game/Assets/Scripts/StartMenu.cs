using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Constants 
{
    // difficulty static variable stored here.
    public static int difficulty;

    void Awake() {
        difficulty = 50;
    }
}

public class StartMenu : MonoBehaviour
{
    // the buttons on the scene
    public Button PlayButton;
    public Button SettingsButton;
    public Button QuitButton;

    void Awake() {
        //MainMenu();

        // set button object to each variable.
        PlayButton = GameObject.Find("PlayButton").GetComponent<Button>();
        SettingsButton = GameObject.Find("SettingsButton").GetComponent<Button>();
        QuitButton = GameObject.Find("QuitButton").GetComponent<Button>();

        // Listeners on the buttons.
        PlayButton.onClick.AddListener(StartGame);
        SettingsButton.onClick.AddListener(Settings);
        QuitButton.onClick.AddListener(QuitGame);
    }

    // Methods for when the buttons are pressed.
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
