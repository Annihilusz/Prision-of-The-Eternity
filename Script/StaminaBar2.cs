using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar2 : MonoBehaviour
{
    private float stamina;
    private float lerpTimer;
    public float maxStamina = 100f;
    public float chipSpedd = 2f;
    public Image frontStaminaBar;
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    void Start()
    {
        stamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        stamina = Mathf.Clamp(stamina, 0, maxStamina);
        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {
        Debug.Log(stamina);
        float fliiF = frontStaminaBar.fillAmount;
        float hFraction = stamina / maxStamina;
        if (fliiF > hFraction)
        {
            frontStaminaBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpedd;
            percentComplete = percentComplete * percentComplete;

        }
        /*if(fliiF < hFraction)
        {
            frontStaminaBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpedd;

        }*/
    }
    
}
