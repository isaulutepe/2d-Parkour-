using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menumanager1 : MonoBehaviour
{
    public GameObject Panel;
    public Scene activeScene;
    public Scene lastScene;  //Kaydedilen Son sahneden devem etmesi için.
    public GameObject levelPanel;
    public GameObject aboutPanel;

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
   public void PlayGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedLevelIndex", 0)); //Kayýtlý indisteki oyun sahneini yükle yoksa sýfýrdan baþla.
        Time.timeScale = 1; //TimeLine ekletileri baþlasýn diye.
    }
    public void OpenLevelPanel()
    {
        levelPanel.SetActive(true);
    }
    public void aplicationQuit()
    {
        Application.Quit();
    }
    public void About()
    {
        aboutPanel.SetActive(true);
    }
    public void closePanel()
    {
        if (aboutPanel.activeSelf == true)
        {
            aboutPanel.SetActive(false);
        }
        if (levelPanel.activeSelf == true)
        {
            levelPanel.SetActive(false);
        }
    }
    //Level Buttons 
    public void Level1Started()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void Level2Started()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void Level3Started()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
    public void Level4Started()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }
    public void Level5Started()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
    }
    public void Level6Started()
    {
        SceneManager.LoadScene(5);
        Time.timeScale = 1;
    }
    public void Level7Started()
    {
        SceneManager.LoadScene(6);
        Time.timeScale = 1;
    }
}
