using System.Collections;
using UnityEngine;

namespace CreatingCharacters.Abilities
{
    public class Dash : Ability
    {
        [SerializeField] private float dashForce;
        [SerializeField] private float dashDuration;

        
        private Rigidbody rb;
        public GameObject dashEffect;
        public Animator animator;
        public AudioClip impact;
        private AudioSource source;
        public float cooldown1 = 2;
        bool isDashing;

        PlayerCtrl ps;

        private void Awake()
        {
            ps = GetComponent<PlayerCtrl>();
            source = GetComponent<AudioSource>();
            rb = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            ///////////////  ห้ามแดช ///////////////
            
            if (staminaBar.instance.currentStamina < 15)
            {
                isDashing = false;
                Debug.Log("No Stamina");
            }

            if (Input.GetKeyDown(KeyCode.Z) && staminaBar.instance.currentStamina >= 15 && ps.currentHealth > 1)
            {
                isDashing = true;
                animator.SetBool("Dashs", true);
                
                if(this.transform.rotation.eulerAngles.y < 100)
                {
                    Instantiate(dashEffect, transform.position, Quaternion.Euler(0f, -90f, 0f));
                    
                }
                else
                {
                    Instantiate(dashEffect, transform.position, Quaternion.Euler(0f, 90f, 0f));
                }
                

                if (isDashing)
                {
                    
                    staminaBar.instance.UseStamina(15);
                    StartCoroutine(Cast());
                   // animator.SetInteger("Dash", 1);
                }
                
            }
            else
            {
                animator.SetBool("Dashs", false);
                isDashing = false;
                //animator.SetInteger("Dash", 0);
            }
           

        }

        public override IEnumerator Cast()
        {
            

            rb.AddForce(transform.forward * dashForce, ForceMode.Impulse);
            source.PlayOneShot(impact, 0.3f);

            yield return new WaitForSeconds(dashDuration);

            rb.velocity = Vector3.zero;
        }
    }
}