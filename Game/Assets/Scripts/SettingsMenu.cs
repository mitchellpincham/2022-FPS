using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    // stuff on scene
    public Button backButton;
    public Slider difficultySlider;

    void Awake() {

        // listner for button
        backButton = GameObject.Find("BackButton").GetComponent<Button>();
        backButton.onClick.AddListener(BackToMenu);

        //difficultySlider = GameObject.Find("difficultySlider").GetComponent<Slider>();
    }
    
    void Update() {
        // get the difficulty each frame
        Constants.difficulty = (int)difficultySlider.value;

        // Debug.Log((int)difficultySlider.value);
    }

    public void BackToMenu() {
        // back button is pressed
        SceneManager.LoadScene("Main Menu");
    }
}
