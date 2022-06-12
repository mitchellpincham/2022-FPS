using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button playButton;

    void Awake() {
        //MainMenu();

        playButton = GameObject.Find("PlayButton").GetComponent<Button>();

        playButton.onClick.AddListener(StartGame);
    }

    void Update() {

    }

    void StartGame() {
        Debug.Log("pogg");
        LoadLevel(1);
    }

    public void LoadLevel(int LevelIndex) {
        SceneManager.LoadScene(LevelIndex);
    }

    public void MainMenu() {
        SceneManager.LoadScene("Main Menu");
    }
}