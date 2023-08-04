using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class yercekimiDegis : MonoBehaviour
{
    [SerializeField] public GameObject _engelCollider;
    [SerializeField] public GameObject _engelCollider2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 12, ForceMode2D.Impulse);
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = -1; //Yerçekimini tersine çevirir.
            StartCoroutine(flipY(collision.gameObject));
            if (collision.gameObject.GetComponent<PlayerController>().jumpForce > 0)
            {
                collision.gameObject.GetComponent<PlayerController>().jumpForce *= -1;
            }
            _engelCollider.SetActive(true);
            _engelCollider2.SetActive(true);
        }
    }
    IEnumerator flipY(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.4f);
        gameObject.GetComponent<SpriteRenderer>().flipY = true;
    }

}
