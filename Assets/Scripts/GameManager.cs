using System;
using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;   
    public TextMeshProUGUI scoreText;
    public static event Action onScoreUpdated;
    public static event Action onGameLost;
    private bool isPause = false;
    [Header("Cài đặt Pause")]
    public RawImage img;
    public Texture pauseTexture;
    public Texture playTexture;
    public GameObject pauseScreen;
    [Header("Cài đặt Restart")]
    public GameObject restartScreen;
    public TextMeshProUGUI HighScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "0";
        img.texture = pauseTexture;
        onScoreUpdated += updateUI;
        pauseScreen.SetActive(false);
        restartScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncreaseScore(int amount)
    {
        score += amount;
        onScoreUpdated?.Invoke();
    }
    public void updateUI()
    {
        scoreText.text = score.ToString();
    }
    public void PauseGame()
    {
        isPause = !isPause;
        if (isPause)
        {
            Time.timeScale = 0;
            img.texture = playTexture;
            pauseScreen.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            img.texture = pauseTexture;
            pauseScreen.SetActive(false);
        }
    }   
    public void LostGame()
    {
        onGameLost?.Invoke();
        restartScreen.SetActive(true);
        if (score > GameStats.highScore)
        {
            GameStats.highScore = score;
        }
        HighScoreText.text += GameStats.highScore.ToString();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
