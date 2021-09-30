using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar2 : MonoBehaviour
{
    private float health;
    private float lerpTimer;
    public float maxHealth = 100f;
    public float chipSpedd = 2f;
    public Image frontHealthBar;

    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {
        
        float fliiF = frontHealthBar.fillAmount;
        float hFraction = health / maxHealth;
        if(fliiF > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpedd;
            percentComplete = percentComplete * percentComplete;

        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            TakeDamage(20);
        }
        else if (collision.gameObject.tag == "Trap")
        {
            TakeDamage(100);
        }
        else if (collision.gameObject.tag == "Boss")
        {
            TakeDamage(30);
        }
    }
}
