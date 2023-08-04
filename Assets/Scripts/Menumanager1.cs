using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menumanager1 : MonoBehaviour
{
    public GameObject Panel;
    public void pause()
    {
        Time.timeScale = 0;
        Panel.SetActive(true);
    }
}
