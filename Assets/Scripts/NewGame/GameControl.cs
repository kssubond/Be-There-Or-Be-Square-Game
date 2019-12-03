using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;

    public AudioSource scoreSound;
    public GameObject gameOverPanel;
    public GameObject startText;
    public GameObject highscore;

    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    public Text scoreText;

    private int score = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        Pause();
    }

    void Update()
    {
        UnPause();
    }
    void Pause()
    {
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;
            startText.SetActive(false);
            highscore.SetActive(false);
        }
    }

    public void BirdScored()
    {
        if (gameOver)
            return;

        score++;
        scoreSound.Play();
        scoreText.text = score.ToString();
    }

    public void BirdDied()
    {
        gameOverPanel.SetActive(true);
        gameOver = true;
        int savedScore = PlayerPrefs.GetInt("Highscore");

        if(score > savedScore)
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
