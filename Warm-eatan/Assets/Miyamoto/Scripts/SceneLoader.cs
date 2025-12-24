using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void SceneLoad(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
