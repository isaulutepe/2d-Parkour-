using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    private Scene ActiveScene;
    [SerializeField] private float gidilecekSahneIndex;

    private void Start()
    {
    }
    void nextSceen()
    {
        Score.totalScore = 0; //Scoru her sahnede s�f�rlamak i�in yapt�m.
        SceneManager.LoadScene((int)gidilecekSahneIndex);
    }


}
