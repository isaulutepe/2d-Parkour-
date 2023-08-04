using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamaraFallow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset; //Kameran�n karaktere olan yak�nl���n� tutan de�i�ken.
    [SerializeField] private float smoothTime; //takip h�z� diyebilece�imiz de�i�ken.

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoohedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothTime);
        transform.position = smoohedPosition;

    }

}
