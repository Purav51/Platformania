using UnityEngine;
using UnityEngine.SceneManagement;

public class GOMenuScript : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }
}
