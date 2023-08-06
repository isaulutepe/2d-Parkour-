using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menumanager1 : MonoBehaviour
{
    public GameObject Panel;
    public Scene activeScene;
    private void Start()
    {
        activeScene = SceneManager.GetActiveScene();
    }
    public void pause()
    {
        Time.timeScale = 0;
        Panel.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        Panel.SetActive(false);
    }
    public void Restart()
    {
        if (activeScene.buildIndex == 6)
        {
            SceneManager.LoadScene(5);
            Time.timeScale = 1;
        }
        else
        {
            SceneManager.LoadScene(activeScene.buildIndex);
            Time.timeScale = 1;

        }

    }
    public void Quit()
    {
        SceneManager.LoadScene(9); //Ana menü Yüklenir.
        Panel.SetActive(false);
    }
}
