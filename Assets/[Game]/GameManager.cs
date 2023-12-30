using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float timer;
    public float totalTime = 60f;
    public TextMeshProUGUI timerText;

    private float score;
    public TextMeshProUGUI scoreText;

    public GameObject winPanel;
    public GameObject losePanel;

    public List<Image> hearts;
    private int health;

    private AudioSource audioSource;
    private void Start()
    {
        Time.timeScale = 1f;
        timer = totalTime;
        
        health = hearts.Count;
        
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        timerText.SetText($"Remaining Time: {timer.ToString("0")}");

        if (timer <= 0)
        {
            winPanel.SetActive(true);
            Debug.Log("Game over!");
            audioSource.Stop();
            Time.timeScale = 0f;
        }
    }

    public void AddScore()
    {
        score++;
        scoreText.SetText($"Score: {score}");
    }

    public void LowerHealth()
    {
        health--;
        hearts[health].gameObject.SetActive(false);
        
        if (health <= 0)
        {
            losePanel.SetActive(true);
            audioSource.Stop();
            Debug.Log("Game over!");
            Time.timeScale = 0f;
        }
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}