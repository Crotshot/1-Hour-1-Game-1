using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Man : MonoBehaviour {
    [SerializeField] TMP_Text timeText, bestScore;
    [SerializeField] GameObject start, pause;
    float time;

    private void Awake() {
        Time.timeScale = 0;
        bestScore.text = "Best Score:" + PlayerPrefs.GetInt("Score").ToString();
    }

    private void Update() {
        if (Time.timeScale == 0)
            return;
        time += Time.deltaTime;
        timeText.text = time.ToString("F0");
        if (Input.GetAxisRaw("Esc") != 0) {
            Time.timeScale = 0;
            pause.SetActive(true);
        }
    }

    public void Resume() {
        Time.timeScale = 1;
        pause.SetActive(true);
    }

    public void StartGame() {
        Time.timeScale = 1;
        start.SetActive(false);
    }

    public void Score() {
        int score = PlayerPrefs.GetInt("Score");

        if(score < (int)time) {
            PlayerPrefs.SetInt("Score", (int)time);
        }
    }
}
