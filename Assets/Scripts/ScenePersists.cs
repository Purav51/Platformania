using UnityEngine;

public class ScenePersists : MonoBehaviour
{
    void Awake()
    {
        int noOfScenePersists = FindObjectsByType<ScenePersists>(FindObjectsSortMode.None).Length;
        if (noOfScenePersists > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void ResetScenePersists()
    {
        Destroy(gameObject);
    }
    
}
