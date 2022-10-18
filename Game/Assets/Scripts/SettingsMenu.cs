using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{ 
    public Button backButton;

    public Slider difficultySlider;

    void Awake() {
        //MainMenu();

        //backButton = GameObject.Find("BackButton").GetComponent<Button>();
        backButton.onClick.AddListener(BackToMenu);

        //difficultySlider = GameObject.Find("difficultySlider").GetComponent<Slider>();
    }
    
    void Update() {
        StartMenu.difficulty = (int)difficultySlider.value;

        Debug.Log((int)difficultySlider.value);
    }

    public void BackToMenu() {
        SceneManager.LoadScene("Main Menu");
    }
}
