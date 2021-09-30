using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coldown : MonoBehaviour
{
    public GameObject player;
    public GameObject Floor;

    [Header("Ability 1")]
    public Image abilityImagel;
    public float cooldown1 = 5;
    bool isCooldown = false;
    public KeyCode ability1;

    [Header("Ability 2")]
    public Image abilityImagel2;
    public float cooldown2 = 5;
    bool isCooldown2 = false;
    public KeyCode ability2;

    [Header("Ability 3")]
    public Image abilityImagel3;
    public float cooldown3 = 5;
    bool isCooldown3 = false;
    public KeyCode ability3;
    void Start()
    {
        abilityImagel.fillAmount = 1;
        abilityImagel2.fillAmount = 1;
        abilityImagel3.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Ability1();
        Ability2();
        Ability3();
    }

    void Ability1()
    {
        if (Input.GetKey(ability1) && isCooldown == false && player.GetComponent<PlayerCtrl>().dJump)
        {
            isCooldown = true;
            abilityImagel.fillAmount = 0;
            
        }

        if (isCooldown)
        {
            abilityImagel.fillAmount += 1 / cooldown2 * Time.deltaTime;

            if(abilityImagel.fillAmount >= 1)
            {
                abilityImagel.fillAmount = 1;
                isCooldown = false;
               
            }
        }
    }

    void Ability2()
    {
        if (Input.GetKey(ability2) && isCooldown2 == false)
        {
            isCooldown2 = true;
            abilityImagel2.fillAmount = 0;
        }

        if (isCooldown2)
        {
            abilityImagel2.fillAmount += 1 / cooldown2 * Time.deltaTime;

            if (abilityImagel2.fillAmount >= 1)
            {
                abilityImagel2.fillAmount = 1;
                isCooldown2 = false;
            }
        }
    }

    void Ability3()
    {
        if (Input.GetKey(KeyCode.R) && isCooldown3 == false && Floor.GetComponent<Revers>().skillRevase)
        {
            isCooldown3 = true;
            abilityImagel3.fillAmount = 0;
        }

        if (isCooldown3)
        {
            abilityImagel3.fillAmount += 1 / cooldown3 * Time.deltaTime;

            if (abilityImagel3.fillAmount >= 1)
            {
                abilityImagel3.fillAmount = 1;
                isCooldown3 = false;
            }
        }
    }
}
