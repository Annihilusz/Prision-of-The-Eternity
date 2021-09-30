using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float hp;
    public GameObject Destroyed;
    public bool breaks = false;
    public AudioClip impact;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            print(hp);
            hp--;
        }
    }

    private void Update()
    {

        if(hp == 0 && !breaks)
        {
            breaks = true;
            GameObject Dt = Instantiate(Destroyed, transform.position, transform.rotation);
            source.PlayOneShot(impact, 0.1f);
            Destroy(Dt, 1.5f);
            Destroy(gameObject,1f);
        }
    }
}
