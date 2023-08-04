using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Level5Platform : MonoBehaviour
{
    [SerializeField] private Animator platform;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            platform.SetTrigger("hareket");
        }
    }

}
