using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    public Animation hingehere;
    public Inventory inventory;
    public GameObject player;
    public bool isDooropen = false;

    public AudioClip impact;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        inventory =  player.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
       /* if (inventory.Key[0] == true)
        {
            hingehere.Play();
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {

        /*if (collision.gameObject.tag == "Player")
        {
             hingehere.Play();
        }*/

        if (collision.gameObject.tag == "Player" && inventory.Key[0])
        {
            
            isDooropen = true;
            hingehere.Play();
            source.PlayOneShot(impact, 0.1f);
            inventory.Key[0] = false;
            Destroy(inventory.slots[0].transform.GetChild(0).gameObject);
            /*if (inventory.Key[0] != null)
            {
                print(123);
                isDooropen = true;
                hingehere.Play();
            }*/
        }
        else
        {
            isDooropen = false;
        }
    }
}
