using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
   public void PlayApp()
    {
        SceneManager.LoadScene("level1");
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    public void AppMenu()
    {
        SceneManager.LoadScene(0);
    }
}
