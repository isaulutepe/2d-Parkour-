using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DikenTetikle : MonoBehaviour
{
   [SerializeField] private Animator anim;

    private void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            anim.SetTrigger("Diken");
        }
    }
}
