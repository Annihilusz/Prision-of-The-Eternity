using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTriger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject dialogueBox;
    public GameObject lockSkill;
    public GameObject player;

    private Gamemaster gm;

    /*public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }*/
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Gamemaster>();
        dialogueBox.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        ///print(1234);
        if(other.tag == "Player")
        {
            //rint(567);
            dialogueBox.SetActive(true);
            lockSkill.SetActive(true);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            gm.Skill[0] = true;
            if (other.tag == "Player" && SceneManager.GetActiveScene().name == "Level3")
            {
                gm.Skill[2] = true;
            }

        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        

        ///if() คุยเสร็จ
        //player.GetComponent<PlayerCtrl>().skillDjump = true;


    }
}
