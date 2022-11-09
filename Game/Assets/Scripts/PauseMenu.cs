using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused;
    GameObject pauseMenuCanvas;
    
    // buttons on the canvas
    public Button resumeButton;
    public Button menuButton;
    public Button quitButton;

    void Awake() {
        // when the game starts set things up.

        pauseMenuCanvas = GameObject.Find("PauseMenu");
        
        ResumeGame();

        // resumeButton = GameObject.Find("ResumeButton").GetComponent<Button>();
        // menuButton = GameObject.Find("MenuButton").GetComponent<Button>();
        // quitButton = GameObject.Find("QuitButton").GetComponent<Button>();

        // add listener methods for each button
        resumeButton.onClick.AddListener(ResumeGame);
        menuButton.onClick.AddListener(MainMenu);
        quitButton.onClick.AddListener(QuitGame);
    }

    void Update() {
        // pause/resume game if key is pressed.
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                ResumeGame();
            } else {
                PauseGame();
            }
        }
    }

    public void MainMenu() {
        SceneManager.LoadScene("Main Menu");
    }

    void QuitGame() {
        Application.Quit();
    }

    public void PauseGame() {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame() {

        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
