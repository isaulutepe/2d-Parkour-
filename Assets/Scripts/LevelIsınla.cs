using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelIsınla : MonoBehaviour
{
    [SerializeField] float gidilecekSahneIndex;
    [SerializeField] GameObject anim1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim1.SetActive(true);
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene((int)gidilecekSahneIndex);
    }



}
