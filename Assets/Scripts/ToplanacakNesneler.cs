using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToplanacakNesneler : MonoBehaviour
{
    public TextMeshProUGUI _text;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Orange")
        {         
            Score.totalScore += 100;
            _text.text = Score.totalScore.ToString();
            Destroy(collision.gameObject, 0.1f); //Ses dosyasýnýn düzgün çalýþmasý için silme iþlemini burada yapýyoruz.
        }
    }
}
