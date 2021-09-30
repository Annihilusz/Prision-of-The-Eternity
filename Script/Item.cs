using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public GameObject ItemUi;
    public GameObject ItemBox;


    public bool isItemScence;

    private void Update()
    {

    }

    private void Start()
    {
        ItemUi.SetActive(false);

    }

    public void OkGame()
    {

        ItemUi.SetActive(false);
        Time.timeScale = 1f;
        isItemScence = false;
    }


    public void Itemscene()
    {
        ItemUi.SetActive(true);
        Time.timeScale = 0f;

    }

    



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isItemScence = true;

            if (isItemScence)
            {
                Itemscene();
                ItemBox.SetActive(false);
            }
        }
        

    }


}
