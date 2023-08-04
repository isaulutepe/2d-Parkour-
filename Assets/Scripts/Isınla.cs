using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Isınla : MonoBehaviour
{
    [SerializeField] private Vector2 position;
    [SerializeField] private float positionX;
    [SerializeField] private float positionY;
    private void Start()
    {
          position = new Vector2(positionX, positionY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            Debug.Log("Kapıda");
            collision.gameObject.GetComponent<Rigidbody2D>().position= position;
        }
    }
}
