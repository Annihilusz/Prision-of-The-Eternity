using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotcut : MonoBehaviour
{
    
    public GameObject bossObj;
    public GameObject player1;
    public Transform[] point;
    // Start is called before the first frame update
    void Start()
    {
        //bs = GetComponent<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            player1.GetComponent<PlayerCtrl>().currentHealth = 1000000;
            player1.GetComponent<PlayerCtrl>().maxHealth = 1000000;
            /* print(bs.hpBoss);
              bs.hpBoss = 0;*/
        }

        if (Input.GetKey(KeyCode.R))
        {
            bossObj.GetComponent<Boss>().hpBoss = 0;
          /* print(bs.hpBoss);
            bs.hpBoss = 0;*/
        }

        if (Input.GetKey(KeyCode.Keypad0))
        {
            transform.position = point[0].position;
        }
        else if (Input.GetKey(KeyCode.Keypad1))
        {
            transform.position = point[1].position;
        }
        else if (Input.GetKey(KeyCode.Keypad2))
        {
            transform.position = point[2].position;
        }
        else if (Input.GetKey(KeyCode.Keypad3))
        {
            transform.position = point[3].position;
        }
        else if (Input.GetKey(KeyCode.Keypad4))
        {
            transform.position = point[4].position;
        }
        else if (Input.GetKey(KeyCode.Keypad5))
        {
            transform.position = point[5].position;
        }
    }
}
