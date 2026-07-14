using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSecretLevel : MonoBehaviour
{
    [SerializeField] float levelLoaddelay = 2f;
    void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LoadSecretLvl());
    }

  IEnumerator LoadSecretLvl()
    {
        yield return new WaitForSecondsRealtime(levelLoaddelay);
        int currSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex;
        if (currSceneIndex == 3)
        {
            nextSceneIndex = 6;
        }
        else if (currSceneIndex == 6)
        {
            nextSceneIndex = 3;
        }
        else
        {
            yield break;
        }
        FindFirstObjectByType<ScenePersists>().ResetScenePersists();
        SceneManager.LoadScene(nextSceneIndex);
    }
}
