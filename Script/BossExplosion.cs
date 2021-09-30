using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossExplosion : MonoBehaviour
{
    Boss bs;
    
    public GameObject explosionEffect;
    public GameObject sphere;
    public GameObject player;

    bool bossSkilluse = false;

    Animator anim;
    void Start()
    {

        bs = GetComponent<Boss>();
        anim = GetComponent<Animator>();

        StartCoroutine(timeWait());
      
    }

    // Update is called once per frame
    void Update()
    {
        if (!bossSkilluse)
        {
            bs.enabled = true;
            //anim.enabled = true;
        }
        else
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);

            if(distance < 2f)
            {
                player.GetComponent<PlayerCtrl>().currentHealth = 0;
            }
            
        }

    }

    IEnumerator bossSkill()
    {
        bossSkilluse = true;
        anim.SetBool("Boom", true);
        bs.GetComponent<NavMeshAgent>().SetDestination(transform.position);
        bs.enabled = false;
        //anim.enabled = false;
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        
        yield return new WaitForSeconds(7f);
        bossSkilluse = false;
        anim.SetBool("Boom", false);
        StartCoroutine(timeWait());



    }

    IEnumerator timeWait()
    {
        yield return new WaitForSeconds(10f);
        StartCoroutine(bossSkill());
    }
}
