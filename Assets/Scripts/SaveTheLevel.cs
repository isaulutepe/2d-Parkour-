using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTheLevel : MonoBehaviour
{
    public int currentLevelIndex = 0; // Oyuncunun geçtiði bölümün indexini tutan deðiþken
    bool touchTheObject = false;

    void Start()
    {
       
        // Oyun baþladýðýnda kaydedilen bölüm indexini PlayerPrefs'ten okuyoruz
        currentLevelIndex = PlayerPrefs.GetInt("SavedLevelIndex", 0);
    }

    void Update()
    {
        if (GetComponent<PlayerController>().finishGame == true)
        {
            touchTheObject= true;
            GetComponent<PlayerController>().finishGame = false;
        }
        // Oyuncu herhangi bir bölümün sonundaki nesneye dokunduðunda
        if (touchTheObject)
        {
            touchTheObject= false;
            currentLevelIndex++; // Bölüm indexini arttýrýyoruz
            PlayerPrefs.SetInt("SavedLevelIndex", currentLevelIndex); // Yeni bölüm indexini PlayerPrefs'e kaydediyoruz
            PlayerPrefs.Save(); // Verileri diske yazýyoruz
                                // Bir sonraki bölüme geçme iþlemleri burada yapýlabilir
        }
        Debug.Log(currentLevelIndex);
    }

}
