using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 4f;
    public float AttRadius = 2f;
    public AudioClip impact;
    private AudioSource source;
    bool audioTest = false;

    Transform target;
    NavMeshAgent agent;
    public Animator animator;

    void Start()
    {
        source = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        print(target);
        target = PlayerManager.instance.player.transform;

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            if (audioTest == false)
            {
                source.PlayOneShot(impact, 0.3f);
                audioTest = true;
            }

            agent.SetDestination(target.position);
            animator.SetInteger("Condition", 1);
        }


        if(distance < AttRadius)
        {
            
            animator.SetBool("Attack",true);
        }
        else
        {
            animator.SetBool("Attack", false);
            animator.SetInteger("Condition", 0);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, AttRadius);
    }


}
