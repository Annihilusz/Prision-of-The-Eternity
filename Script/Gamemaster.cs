using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemaster : MonoBehaviour
{
    private static Gamemaster instance;
    public Vector3 lastCheckPointPos;

    public GameObject player;
    public Text deadScore;
    public int deadCount = 0;

    public bool[] Key = new bool[3];
    public bool[] Skill = new bool[3];

    private void Awake()
    {
        

        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
        
         
        
    }

    public void Update()
    {
        deadScore = GameObject.Find("Count").GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");
        deadScore.text = deadCount.ToString("") ;
    }
}
