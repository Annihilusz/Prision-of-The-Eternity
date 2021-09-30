using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
     public float hpBoss = 1;
    
    /* public float lookRadius = 10f;

     Transform target;
     NavMeshAgent agent;
     Animator animator;

     void Start()
     {
         agent = GetComponent<NavMeshAgent>();
         target = PlayerManager.instance.player.transform;
         animator = GetComponent<Animator>();
     }


     void Update()
     {
         float distance = Vector3.Distance(target.position, transform.position);

         if (distance < lookRadius)
         {
             agent.SetDestination(target.position);

         }
     }

     private void OnDrawGizmosSelected()
     {
         Gizmos.color = Color.red;
         Gizmos.DrawWireSphere(transform.position, lookRadius);
     }*/
    public float lookRadius = 10f;
    public float AttRadius = 2f;
    public GameObject bossFire;
    public Transform fireSpawn;
    public GameObject shootEffect;
    public GameObject dieEffect;
    //public GameObject skillBoss;
    public Transform bossWaypoint;
    public Transform bossWaypoint2;
    public AudioClip impact;
    private AudioSource source;
    private Gamemaster gm;
    bool wayPoint = true;
    bool audioTest = false;
    bool canShoot = true;

    
    Transform target;
    NavMeshAgent agent;
    public Animator animator;

    void Start()
    {
        source = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.player.transform;
        animator = GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Gamemaster>();
    }


    void Update()
    {
        
        float distance = Vector3.Distance(target.position, transform.position);

        
        if(hpBoss == 0 && animator.GetInteger("Run") == 1 )
        {
            
            //print(animator.GetInteger("Run"));
            animator.SetInteger("Run", 0);
            StartCoroutine(dieDelay());

        }
        else if(hpBoss > 0)
        {
            if (distance <= lookRadius)
            {
                if (audioTest == false)
                {
                    source.PlayOneShot(impact, 0.3f);
                    audioTest = true;
                }

                agent.SetDestination(target.position);
                animator.SetInteger("Run", 1);
            }
            else if(Vector3.Distance(bossWaypoint2.position, transform.position) < 1.1f && wayPoint)
            {
                agent.SetDestination(bossWaypoint.position);
                animator.SetInteger("Run", 1);
                wayPoint = false;
            }
            else if(Vector3.Distance(bossWaypoint.position, transform.position) < 1.1f)
            {
                //print(Vector3.Distance(bossWaypoint2.position, transform.position));
                agent.SetDestination(bossWaypoint2.position);
                animator.SetInteger("Run", 1);
                wayPoint = true;
            }
            else if(wayPoint)
            {
                agent.SetDestination(bossWaypoint2.position);
                animator.SetInteger("Run", 1);
            }
            else
            {
                agent.SetDestination(bossWaypoint.position);
                animator.SetInteger("Run", 1);
            }


            if (distance < AttRadius && canShoot)
            {
                animator.SetBool("Att", true);
                Fire();
                //Instantiate(shootEffect, transform.position, Quaternion.identity);

            }
            else if (distance > AttRadius)
            {
                animator.SetBool("Att", false);
                //animator.SetInteger("Run", 0);
            }
            
        }

        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, AttRadius);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Boxtrap")
        {
            hpBoss--; 
        }
    }

    void Die()
    {
        
        Destroy(gameObject, 2f);
        this.enabled = !enabled;
    }

    void Fire()
    {
        GameObject bullet = (GameObject)Instantiate(bossFire, fireSpawn.position, fireSpawn.rotation);
        //bullet.transform.Rotate(180, 0, 0);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 7.0f;

        
        canShoot = false;
        //Destroy(bullet, 2);
        StartCoroutine(ShootDelay());
    }


    IEnumerator ShootDelay()
    {
        
        //canShoot = false;
        yield return new WaitForSeconds(2f);
        canShoot = true;
    }


    IEnumerator dieDelay()
    {

        Instantiate(dieEffect, transform.position, Quaternion.identity);
        //canShoot = false;
        
        yield return new WaitForSeconds(2f);
        //Die();
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            gm.Key = new bool[3];
            SceneManager.LoadScene("Endscene");
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            gm.Key = new bool[3];
            SceneManager.LoadScene("Endscene2");
        }
        else
        {
            gm.Key = new bool[3];
            
            SceneManager.LoadScene("Endscene3");
        }

    }


    /*IEnumerator skillDelay()
    {
        Instantiate(skillBoss, transform.position, Quaternion.identity);
        //canShoot = false;
        yield return new WaitForSeconds(60f);
        
    }*/
}
