using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActivation : MonoBehaviour
{
    public GameObject traps;
    public Transform trapPos;
    public PlayerCtrl scriptA;

    public AudioClip impact;
    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Player")
        {
            /*GameObject trap = Instantiate(traps, trapPos.position, Quaternion.identity);

            Destroy(trap, 1f);*/
            StartCoroutine(trapDelay());

        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            scriptA.TakeDamage(10);
  
        }
    }

    IEnumerator trapDelay()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject trap = Instantiate(traps, trapPos.position + new Vector3(i, 0, 0), Quaternion.identity);
            Destroy(trap, 1.5f);
            source.PlayOneShot(impact, 0.3f);
            yield return new WaitForSeconds(0.5f);
        }

    }

}
