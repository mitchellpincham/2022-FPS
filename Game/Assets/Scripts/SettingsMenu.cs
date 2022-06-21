using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{ 
    public Button backButton;

    void Awake() {
        //MainMenu();

        backButton = GameObject.Find("BackButton").GetComponent<Button>();

        backButton.onClick.AddListener(BackToMenu);
    }

    public void BackToMenu() {
        SceneManager.LoadScene("Main Menu");
    }
}
