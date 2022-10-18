using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Text enemiesLeftText;

    void Awake() {
        enemiesLeftText = GameObject.Find("Canvas/EnemiesLeft").GetComponent<Text>();
    }

    void Update() {
        int enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
        
        switch (enemiesLeft) {
            case 0:
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("Main Menu");
                break;
            case 1:
                enemiesLeftText.text = "1 enemy left";
                break;
            default:
                enemiesLeftText.text = enemiesLeft.ToString() + " enemies left";
                break;
        }
    }

    public void LoadLevel(int LevelIndex) {
        SceneManager.LoadScene(LevelIndex);
    }
}