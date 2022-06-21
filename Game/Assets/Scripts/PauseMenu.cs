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
    
    public Button resumeButton;
    public Button menuButton;
    public Button quitButton;

    void Awake() {
        pauseMenuCanvas = GameObject.Find("PauseMenu");
        pauseMenuCanvas.SetActive(false);
        isPaused = false;

        // resumeButton = GameObject.Find("ResumeButton").GetComponent<Button>();
        // menuButton = GameObject.Find("MenuButton").GetComponent<Button>();
        // quitButton = GameObject.Find("QuitButton").GetComponent<Button>();

        resumeButton.onClick.AddListener(Resume);
        menuButton.onClick.AddListener(MainMenu);
        quitButton.onClick.AddListener(QuitGame);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.BackQuote)) {
            if (isPaused) {
                ResumeGame();
            } else {
                PauseGame();
            }
        }
    }

    void Resume() {
        ResumeGame();
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

        Debug.Log("Yes");

        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
