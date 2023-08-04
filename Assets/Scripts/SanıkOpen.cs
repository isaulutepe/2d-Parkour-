using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanıkOpen : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject key;
    [SerializeField] private Animator engelAnim; 
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Open");
            key.SetActive(true);
            engelAnim.SetTrigger("yıkıl");
        }
    }
}
