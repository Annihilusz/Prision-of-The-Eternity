using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Omifly : MonoBehaviour
{
    public float speed;

    public Transform flyto;

    void Update()
    { 
        float step = speed * Time.deltaTime;
        transform.LookAt(flyto);
        transform.position = Vector3.MoveTowards(transform.position, flyto.position, step);
    }
}

