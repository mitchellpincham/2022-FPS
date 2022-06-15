using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    void Awake() {
        //MainMenu();
    }

    void Update() {
        /////////
    }

    public void LoadLevel(int LevelIndex) {
        SceneManager.LoadScene(LevelIndex);
    }
}