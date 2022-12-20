using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SceneManager : MonoBehaviour
{
    public string LoadSceneName;

    public void LoadScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(LoadSceneName);
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void LoadScene(string sceneName) {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

}
