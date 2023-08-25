using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void GoToScene(string sceneName) {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void ExitApplication() {
        Application.Quit();
    }
}
