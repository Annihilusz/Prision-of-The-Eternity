using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    public Component doorColliderhere;
    public GameObject keygone;
    public bool isKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isKey = true;
            doorColliderhere.GetComponent<BoxCollider>().enabled = true;
            keygone.SetActive(false);
        }
        
    }
}
