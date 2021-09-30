using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy2 : MonoBehaviour
{
    public float hp;
    public GameObject Destroyed;
    public bool breaks = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //print(hp);
            hp--;
        }
    }

    private void Update()
    {

        if (hp == 0 && !breaks)
        {
            breaks = true;
            GameObject Dt = Instantiate(Destroyed, transform.position, transform.rotation);

            Destroy(Dt, 2f);
            Destroy(gameObject, 1f);
        }
    }
}
