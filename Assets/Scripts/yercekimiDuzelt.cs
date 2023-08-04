using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yercekimiDuzelt : MonoBehaviour
{
    [SerializeField] private GameObject _engelCollider;
    [SerializeField] private GameObject _engelCollider2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Döndün");
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 12, ForceMode2D.Impulse);
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1; //Yerçekimini tersine çevirir.
            StartCoroutine(flipY(collision.gameObject));
            if (collision.gameObject.GetComponent<PlayerController>().jumpForce < 0)
            {
                collision.gameObject.GetComponent<PlayerController>().jumpForce *= -1;
            }
            else { collision.gameObject.GetComponent<PlayerController>().jumpForce *= 1; }
            _engelCollider.SetActive(false);
            _engelCollider2.SetActive(false);
        }
    }

    IEnumerator flipY(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.4f);
        gameObject.GetComponent<SpriteRenderer>().flipY = false;
    }
}
