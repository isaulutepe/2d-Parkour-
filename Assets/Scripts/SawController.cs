using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SawController : MonoBehaviour
{
    private bool right = true;
    [SerializeField] private float speed;
    [SerializeField] private float leftMove;
    [SerializeField] private float rightMove;

    private void FixedUpdate()
    {
        if (right)
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
        if (transform.position.x > rightMove)
        {
            right = false;
        }
        else if (transform.position.x < leftMove)
        {
            right = true;
        }
    }
}
