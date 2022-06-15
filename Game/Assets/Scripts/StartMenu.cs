using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Button playButton;

    void Awake() {
        //MainMenu();

        playButton = GameObject.Find("PlayButton").GetComponent<Button>();

        playButton.onClick.AddListener(StartGame);
    }

    void Update() {
        /////////
    }

    void StartGame() {
        SceneManager.LoadScene(1);
    }
}
