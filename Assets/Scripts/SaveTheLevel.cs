using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTheLevel : MonoBehaviour
{
    public int currentLevelIndex = 0; // Oyuncunun ge�ti�i b�l�m�n indexini tutan de�i�ken
    bool touchTheObject = false;

    void Start()
    {
       
        // Oyun ba�lad���nda kaydedilen b�l�m indexini PlayerPrefs'ten okuyoruz
        currentLevelIndex = PlayerPrefs.GetInt("SavedLevelIndex", 0);
    }

    void Update()
    {
        if (GetComponent<PlayerController>().finishGame == true)
        {
            touchTheObject= true;
            GetComponent<PlayerController>().finishGame = false;
        }
        // Oyuncu herhangi bir b�l�m�n sonundaki nesneye dokundu�unda
        if (touchTheObject)
        {
            touchTheObject= false;
            currentLevelIndex++; // B�l�m indexini artt�r�yoruz
            PlayerPrefs.SetInt("SavedLevelIndex", currentLevelIndex); // Yeni b�l�m indexini PlayerPrefs'e kaydediyoruz
            PlayerPrefs.Save(); // Verileri diske yaz�yoruz
                                // Bir sonraki b�l�me ge�me i�lemleri burada yap�labilir
        }
        Debug.Log(currentLevelIndex);
    }

}
