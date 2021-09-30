using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class staminaBar : MonoBehaviour
{
    public Slider staminaBars;
    
    public Image fill;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public int maxStamina = 100;
    public int currentStamina;

    public static staminaBar instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentStamina = maxStamina;
        staminaBars.maxValue = maxStamina;
        staminaBars.value = maxStamina;
    }

    public void UseStamina(int amount)
    {
        if(currentStamina - amount >= 0)
        {
            currentStamina -= amount;
            staminaBars.value = currentStamina;
            


            if (regen != null)
                StopCoroutine(regen);

            regen
                = StartCoroutine(RegenStamina());
        }
        /*else
        {
            Debug.Log("No Stamina");
        }*/

    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);


        while(currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 100;
            staminaBars.value = currentStamina;
            

            yield return regenTick;
        }

        regen = null;
    }
}
