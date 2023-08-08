using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private GameObject blackScreen;
    [SerializeField] private GameObject ScorePanel;
    private AudioSource source;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            source.Play();
            Debug.Log("Oyunn Bitti");
            animator.SetTrigger("Finish");
        }
    }

    private void BlackScreen() //Karakter bayraða dokunduktan sonra animasyon bitecek ve kararan ekran çaðrýlacak.
    {
        ScorePanel.SetActive(false);
        blackScreen.SetActive(true);
    }
}
