using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brake : MonoBehaviour
{
    public GameObject fractured;
    public float breakForce;


    public PlayerCtrl Pl;

    void Update()
    {
        float dis = Vector3.Distance(transform.position, Pl.gameObject.transform.position);
        
        if (Input.GetKeyDown("F") && Pl.StaminaBar.currentStamina > 20)
        {
            staminaBar.instance.UseStamina(20);
            BreakTheThing();
        }
    }

    public void BreakTheThing()
    {
        GameObject frac = Instantiate(fractured, transform.position, transform.rotation);

        foreach (Rigidbody rb in frac.GetComponentsInChildren<Rigidbody>())
        {
            Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
            rb.AddForce(force);
        }
        Destroy(gameObject);

        //
    }
}
