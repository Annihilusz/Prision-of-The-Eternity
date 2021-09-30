using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private Gamemaster gm;

    public AudioClip impact;
    private AudioSource source;

    public GameObject itemEffect;
    

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Gamemaster>();
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("Player"))
        {
            gm.lastCheckPointPos = transform.position;
            Instantiate(itemEffect, transform.position, Quaternion.identity);
            source.PlayOneShot(impact, 0.1f);

        }
        
    }

    
}
