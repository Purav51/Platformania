using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int Score = 0;
    [SerializeField] TextMeshProUGUI LivesText;
    [SerializeField] TextMeshProUGUI ScoreText;
    void Awake()
    {
        int noOfGameSessions = FindObjectsByType<GameSession>(FindObjectsSortMode.None).Length;
        if (noOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        LivesText.text = playerLives.ToString();
        ScoreText.text = Score.ToString();
    }
    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }
    public void AddToScore(int pointsToAdd)
    {
        Score += pointsToAdd;
        ScoreText.text = Score.ToString();
    }

    void TakeLife()
    {
        playerLives = playerLives - 1;
        int currSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currSceneIndex);
        LivesText.text = playerLives.ToString();
    }

    void ResetGameSession()
    {
        FindFirstObjectByType<ScenePersists>().ResetScenePersists();
        SceneManager.LoadScene(5);
        Destroy(gameObject);
    }
    public int getScore()
    {
        return Score;
    }
}
