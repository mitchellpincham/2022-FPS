using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public Button Level1Button;
    public Button Level2Button;
    public Button Level3Button;
    public Button BackButton;

    void Awake() {
        Level1Button = GameObject.Find("Level1Button").GetComponent<Button>();
        Level2Button = GameObject.Find("Level2Button").GetComponent<Button>();
        Level3Button = GameObject.Find("Level3Button").GetComponent<Button>();
        BackButton = GameObject.Find("BackButton").GetComponent<Button>();

        Level1Button.onClick.AddListener(delegate{LoadLevel(1);});
        Level2Button.onClick.AddListener(delegate{LoadLevel(2);});
        Level3Button.onClick.AddListener(delegate{LoadLevel(3);});
        BackButton.onClick.AddListener(MainMenu);
    }

    public void MainMenu() {
        SceneManager.LoadScene("Main Menu");
    }

    void LoadLevel(int levelNum) {
        SceneManager.LoadScene("Level " + levelNum.ToString("D2"));
    }
}
