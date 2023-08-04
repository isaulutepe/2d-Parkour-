using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandMove : MonoBehaviour
{
    private Vector2 konum;
    [SerializeField] private float Yukar�;
    [SerializeField] private float asag�; 
    [SerializeField] private float speed;
    private bool yonCevir;
    private void FixedUpdate()
    {
        if (yonCevir) //A�as� d�nmesini sa�lar.
        {
            konum = new Vector2(transform.position.x, transform.position.y - (Time.deltaTime * speed));
            transform.position = konum;
        }
        else
        {
            konum = new Vector2(transform.position.x, transform.position.y + (Time.deltaTime * speed));
            transform.position = konum;
        }
        if (transform.position.y >= Yukar�)
        {
            yonCevir = true;
        }

        if (transform.position.y <= asag�) //Tekrar yukar� d�nmesini sa�llar.
        {
            yonCevir = false;
        }
    }

}
