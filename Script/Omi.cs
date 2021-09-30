using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Omi : MonoBehaviour
{
    public float lookRadius = 4f;
    public float AttRadius = 2f;
    public AudioClip impact;
    private AudioSource source;
    bool audioTest = false;
    public float speed;
    public Transform flyto;

    Transform target;
    
    Animator animator;

    void Start()
    {
        source = GetComponent<AudioSource>();
        

        animator = GetComponent<Animator>();
    }


    void Update()
    {
        float step = speed * Time.deltaTime;

       
        
        target = PlayerManager.instance.player.transform;

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            if (audioTest == false)
            {
                source.PlayOneShot(impact, 1f);
                audioTest = true;
            }

            FlyTo();
            
        }
       

        if (distance < AttRadius)
        {
            
            animator.SetBool("Att", true);
        }
        else
        {
            animator.SetBool("Att", false);
            
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, AttRadius);
    }

    void FlyTo()
    {
        float step = speed * Time.deltaTime;
        transform.LookAt(flyto);
        transform.position = Vector3.MoveTowards(transform.position, flyto.position, step);
    }
}
