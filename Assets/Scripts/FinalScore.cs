using UnityEngine;
using TMPro;
public class FinalScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;
    void Start()
    {
        GameSession gameSession = FindFirstObjectByType<GameSession>();
        if (gameSession != null)
        {
            ScoreText.text = gameSession.getScore().ToString();
            gameSession.transform.Find("Canvas").gameObject.SetActive(false);
        }
    }
    public void ExitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }
}
