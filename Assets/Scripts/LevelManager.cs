using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons;

    public void Start()
    {
       // PlayerPrefs.DeleteAll(); //kayýtlarý silme için , test amaçlý

        foreach (var levelButton in levelButtons)
        {
            levelButton.enabled = false; //Level 1 hariç bütün butonlar kapalý olacak
        }
        levelButtons[0].enabled = true; //Birinci Bölüm butonu
        int savedLevelIndex = PlayerPrefs.GetInt("SavedLevelIndex", 0);//Kayýtlý indis deðerini getirdik.
        Debug.Log("Saved level index: " + savedLevelIndex);

        // Kaydedilen bölüm indexine kadar olan butonlarý aktif hale getiriyoruz
        for (int i = 1; i <= savedLevelIndex; i++)
        {
            levelButtons[i].enabled = true;
        }
    }
}
