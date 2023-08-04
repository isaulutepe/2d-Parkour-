using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tranbolin : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float JumpForce;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("jump"); //tranbolini zýplatan ainmasyon.
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            StartCoroutine(wait());
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.4f); //Animasyon bitine kadar bekle.
        anim.ResetTrigger("jump");
        anim.Play("tranbolinIdle");
        
    }
}
