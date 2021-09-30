using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    public AudioClip impact;
    private AudioSource source;
    public GameObject itemEffect;
    bool audioTests = false;

    private Gamemaster gm;
    private void Start()
    {
        source = GetComponent<AudioSource>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Gamemaster>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioTests == false)
            {
                source.PlayOneShot(impact, 0.3f);
                audioTests = true;
            }
            print("You got Key ");

            for(int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.Key[i] == false)
                {
                    gm.Key[i] = true;
                    inventory.Key[i] = true;
                    Instantiate(itemEffect, transform.position, Quaternion.identity);
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject,0.9f);
                    break;
                }
            }
        }
    }
}
