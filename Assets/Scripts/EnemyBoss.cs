using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private float distanceBetween;
    private float distance;
    [SerializeField] private GameObject startPosition;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan(direction.x) + Mathf.Rad2Deg;
        

        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
        else
        {
            transform.position = Vector2.MoveTowards(this.transform.position, startPosition.transform.position,speed * Time.deltaTime);
        }
        if (transform.position.x < player.transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        if (transform.position.x > player.transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Kendi konumuna geri dönmeli.
            transform.position = startPosition.transform.position; 
        }
    }


}
