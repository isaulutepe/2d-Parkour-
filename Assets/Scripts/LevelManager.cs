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
       // PlayerPrefs.DeleteAll(); //kay�tlar� silme i�in , test ama�l�

        foreach (var levelButton in levelButtons)
        {
            levelButton.enabled = false; //Level 1 hari� b�t�n butonlar kapal� olacak
        }
        levelButtons[0].enabled = true; //Birinci B�l�m butonu
        int savedLevelIndex = PlayerPrefs.GetInt("SavedLevelIndex", 0);//Kay�tl� indis de�erini getirdik.
        Debug.Log("Saved level index: " + savedLevelIndex);

        // Kaydedilen b�l�m indexine kadar olan butonlar� aktif hale getiriyoruz
        for (int i = 1; i <= savedLevelIndex; i++)
        {
            levelButtons[i].enabled = true;
        }
    }
}
