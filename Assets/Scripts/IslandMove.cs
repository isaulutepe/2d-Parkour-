using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandMove : MonoBehaviour
{
    private Vector2 konum;
    [SerializeField] private float Yukarý;
    [SerializeField] private float asagý; 
    [SerializeField] private float speed;
    private bool yonCevir;
    private void FixedUpdate()
    {
        if (yonCevir) //Aðasý dönmesini saðlar.
        {
            konum = new Vector2(transform.position.x, transform.position.y - (Time.deltaTime * speed));
            transform.position = konum;
        }
        else
        {
            konum = new Vector2(transform.position.x, transform.position.y + (Time.deltaTime * speed));
            transform.position = konum;
        }
        if (transform.position.y >= Yukarý)
        {
            yonCevir = true;
        }

        if (transform.position.y <= asagý) //Tekrar yukarý dönmesini saðllar.
        {
            yonCevir = false;
        }
    }

}
