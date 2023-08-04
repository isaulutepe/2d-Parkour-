using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamaraFallow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset; //Kameranýn karaktere olan yakýnlýðýný tutan deðiþken.
    [SerializeField] private float smoothTime; //takip hýzý diyebileceðimiz deðiþken.

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoohedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothTime);
        transform.position = smoohedPosition;

    }

}
