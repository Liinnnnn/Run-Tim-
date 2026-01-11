using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;   
    public TextMeshProUGUI scoreText;
    public static event Action onScoreUpdated;
    private bool isPause = false;
    [Header("Cài đặt Pause")]
    public RawImage img;
    public Texture pauseTexture;
    public Texture playTexture;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "0";
        img.texture = pauseTexture;
        onScoreUpdated += updateUI;
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
        }
        else
        {
            Time.timeScale = 1;
            img.texture = pauseTexture;
        }
    }   
}
