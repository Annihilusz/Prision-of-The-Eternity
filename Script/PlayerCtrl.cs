using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed;

    public float jumpForce;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public CharacterController controller;
    public Animator animator;
    public Rigidbody _rigidbody;

    public Vector3 moveDirection;
    public float gravityScale;

    private Gamemaster gm;
    
    public staminaBar StaminaBar;

    public bool dJump = false;
    public bool skillDjump = false;
    
    Revers rs;
    public GameObject doubleEffect;
    public GameObject revesEffect;
    public GameObject skillBrake;
    public GameObject skilldjump;
    public GameObject skillReves;

    void Start()
    {
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        _rigidbody = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Gamemaster>();
        transform.position = gm.lastCheckPointPos;

        if (gm.Skill[0])
        {
            
            skillBrake.SetActive(true);
        }
        if (gm.Skill[1])
        {
            skillDjump = true;
            skilldjump.SetActive(true);
        }
        if(gm.Skill[2])
        {
            skillReves.SetActive(true);
            rs.skillRevase = true;
        }
    }

   /* void UpdateUi()
    {
        if (gm.Skill[0])
        {

            skillBrake.SetActive(true);
        }
        if (gm.Skill[1])
        {
            skillDjump = true;
            skilldjump.enabled = true;
        }
        if (gm.Skill[2])
        {
            rs.skillRevase = true;
        }
    }*/

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C) && gm.Skill[2])
        {
            Effcetreves();
        }
        
            //Vector3 characterScale = transform.localScale;
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y);
        

        if (moveDirection.x > 1)
        {
            //characterScale.x = 10;
            animator.SetInteger("Runing", 1);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime * moveSpeed);
        }
        else if (moveDirection.x < -1)
        {
            //characterScale.x = -10;
            animator.SetInteger("Runing", 1);
            //transform.Rotate(0, Mathf.Clamp(Time.deltaTime * moveSpeed ,90,270) , 0, Space.Self);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,270,0), Time.deltaTime * moveSpeed);
        }
        else
        {
            animator.SetInteger("Runing", 0);
        }

        /*if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                print(123);
                moveDirection.y = jumpForce;
                animator.SetInteger("corition", 3);
            }
            else
                animator.SetInteger("corition", 0);
        }
        else
        {
            print(4567);
            if (Input.GetButtonDown("Jump") && staminaBar.instance.currentStamina > 80)
            {
                staminaBar.instance.UseStamina(80);
                moveDirection.y = jumpForce;
                animator.SetInteger("corition", 3);
            }
            
        }*/
            //transform.localScale = characterScale;

        /*if (currentHealth < 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }*/


        //moveDirection.y = moveDirection.y + (Physics.gravity.y + gravityScale);
        //controller.Move(moveDirection * Time.deltaTime);

        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * moveSpeed;

        /*if (!Mathf.Approximately(0, movement))
        {
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }*/

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            animator.SetInteger("corition", 3);
            
            _rigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            

        }
        else if(Mathf.Abs(_rigidbody.velocity.y) > 0.001f)
        {
            if (Input.GetButtonDown("Jump") && staminaBar.instance.currentStamina > 50 && skillDjump)
            {
                staminaBar.instance.UseStamina(30);
                Instantiate(doubleEffect, transform.position, Quaternion.identity);
                _rigidbody.AddForce(new Vector3(0, jumpForce/1.0f, 0), ForceMode.Impulse); //เปลี่ยนการกระโดดครั้งที่สองด้วย jumpForce / .... // 
                dJump = true;
                // Effect Double jump //
            }
        }
        else
        {
            dJump = false;
            animator.SetInteger("corition", 0);
           
        }

        if (currentHealth < 1)
        {
            gm.deadCount ++;
            StartCoroutine(deadDelays());
            
        }
        else
        {
            animator.SetBool("Dead", false);
        }

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            TakeDamage(10);
        }
        else if(collision.gameObject.tag == "Trap")
        {
            TakeDamage(100);
        }
        else if (collision.gameObject.tag == "Boss")
        {
            TakeDamage(25);
        }
       


    }


    IEnumerator deadDelays()
    {
        
        enabled = !enabled;
        animator.SetBool("Dead", true);
        yield return new WaitForSeconds(2.1f); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //UpdateUi();
    }

    
   

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    public void Effcetreves()
    {
        Instantiate(revesEffect, transform.position, Quaternion.identity);
    }
    /*public void Flip(float moveDirection)
    {
        if(moveDirection > 0 && !facingRight || moveDirection < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }*/


}
