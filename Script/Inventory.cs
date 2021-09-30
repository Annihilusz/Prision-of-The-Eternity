using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] Key;
    public GameObject[] slots;
    private Gamemaster gm;
    public GameObject itemButton;

   

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Gamemaster>();

        for (int i = 0; i < gm.Key.Length; i++)
        {
            if ( gm.Key[i] )
            {
                Key[i] = true;
                Instantiate(itemButton,slots[i].transform, false);
            }
        }
    }

    private void Update()
    {
        
    }
}
