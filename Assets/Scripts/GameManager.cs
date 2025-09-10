using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public GameObject playButton;
    public GameObject gameSign;
    public GameObject overSign;
    public BirdPlayer player; 

    private int gameScore;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        PauseGame();

    }

    public void PlayGame()
    {
        gameScore = 0;
        scoreText.text = gameScore.ToString();

        playButton.SetActive(false);
        gameSign.SetActive(false);
        overSign.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        MovePipes[] pipes = FindObjectsOfType<MovePipes>();
        for (int i = 0; i < pipes.Length; i++) 
        { 
            Destroy(pipes[i].gameObject);
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void AddScore()
    {
        gameScore++;
        scoreText.text = gameScore.ToString();

    }

    public void GameOver()
    {
        gameSign.SetActive(true);
        overSign.SetActive(true);
        playButton.SetActive(true);
        PauseGame();
    }
}
