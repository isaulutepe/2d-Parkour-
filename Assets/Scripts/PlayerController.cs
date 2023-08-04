using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private CapsuleCollider2D capsuleCollider2D; //Karakter öldüðünde devre dýþý býrakýlacak sonra aktif edilecek.
    private Animator animator;
    [SerializeField] private float speed;
    private SpriteRenderer spriteRenderer; //Karekterin Yönünü çevirmek için.
    private bool jumpActive = false;
    [SerializeField] public float jumpForce;
    private bool isground = true;
    private AudioSource dieSound;
    [SerializeField] private Transform startPoint;
    [SerializeField] public GameObject _engelCollider;
    [SerializeField] public GameObject _engelCollider2;
    [SerializeField] private float waitTime; //Kamerayý bekleme süresi.
    [SerializeField] GameObject WaitTrigger; //Kameralarý bekleten trigger tetiklendikten sonra devre dýþý olmalý.
    float moveRotation;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        dieSound = GetComponent<AudioSource>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }
    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate() //Rigidbody Ýþlemleri Fixed Update içinde yapýlýr.
    {
        // moveRotation = Input.GetAxis("Horizontal");
        rigidBody2D.velocity = new Vector2(moveRotation * speed, rigidBody2D.velocity.y);
        if (moveRotation != 0)
            animator.SetFloat("speed", 1);
        else
            animator.SetFloat("speed", 0);
        if (jumpActive)
        {
            animator.SetTrigger("jump");
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpForce);
            isground = false;
            animator.SetBool("grounded", false);
            jumpActive = false;
        }

    }
    private void Update()
    {
        //Karakterin yönü.
        if (rigidBody2D.velocity.x > 0.01f)
            spriteRenderer.flipX = false;
        else if (rigidBody2D.velocity.x < -0.01f)
        {
            spriteRenderer.flipX = true;
        }
        //Zýplama Kontrolü -> Karakter yerde ise
        if (Input.GetKeyDown(KeyCode.Space) && isground == true)
        {
            jumpActive = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isground = true;
            animator.SetBool("grounded", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Karakteri sabitlemek için.
            rigidBody2D.gravityScale = 0;
            capsuleCollider2D.enabled = false;
            rigidBody2D.velocity = Vector2.zero;
            //Karakter hareketlerini durdurmak için.
            GetComponent<PlayerController>().enabled = false;

            dieSound.Play();
            animator.SetTrigger("die");
        }
        if (collision.gameObject.tag == "Finish") //Oyun bitti.
        {
            animator.SetFloat("speed", 0);
            rigidBody2D.velocity = Vector2.zero; //Karakteri sabitlemek için.
            GetComponent<PlayerController>().enabled = false;
        }
        if (collision.gameObject.tag == "waitCamera")
        {
            StartCoroutine(WaitCamera(waitTime));
            WaitTrigger.SetActive(false);
        }
    }
    private void Respawn() //Die Anim bunu çalýþýracak.
    {
        if (spriteRenderer.flipY == true) //Tavanda ölürse diye.
        {
            rigidBody2D.gravityScale = 1;
            capsuleCollider2D.enabled = true;
            transform.position = startPoint.position;
            animator.ResetTrigger("die");
            animator.Play("PlayerIdle");
            spriteRenderer.flipY = false;
            jumpForce *= -1;
            GetComponent<PlayerController>().enabled = true;
            _engelCollider.SetActive(false);
            _engelCollider2.SetActive(false);
        }
        rigidBody2D.gravityScale = 1;
        capsuleCollider2D.enabled = true;
        transform.position = startPoint.position;
        animator.ResetTrigger("die");
        animator.Play("PlayerIdle");
        GetComponent<PlayerController>().enabled = true;
    }
    //Baþlangýçta kameranýn mapi gezmesi için beklenecek süre.
    IEnumerator WaitCamera(float time)
    {
        GetComponent<PlayerController>().enabled = false; //Bekle.
        yield return new WaitForSeconds(time);
        GetComponent<PlayerController>().enabled = true;
    }


    public void LeftMove()
    {
        moveRotation = -1;

    }
    public void RightMove()
    {
        moveRotation = 1;
    }
    public void JumpMove()
    {
        if (isground == true)
        {
            jumpActive = true;
        }
    }
    public void Stop()
    {
        moveRotation = 0;
    }
}