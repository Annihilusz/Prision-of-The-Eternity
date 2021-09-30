using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog_new : MonoBehaviour
{
    public Text textDisplay;
    [TextArea(3, 10)]
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject continueButton;
    public GameObject startlevel;
    public Image[] imageScene;

    void Start()
    {
        StartCoroutine(Type());
    }

    void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }
    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if(index < sentences.Length - 1)
        {
            if(index == 0)
            {
                imageScene[0].enabled = false;
                
            }
            else if(index == 1)
            {
                imageScene[1].enabled = false;

            }
            else if (index == 2)
            {
                imageScene[2].enabled = false;

            }
            else if (index == 3)
            {
                imageScene[3].enabled = false;

            }
            else if (index == 4)
            {
                imageScene[4].enabled = false;

            }
            else if (index == 5)
            {
                imageScene[5].enabled = false;

            }
            else if (index == 6)
            {
                imageScene[6].enabled = false;

            }
            else if (index == 7)
            {
                imageScene[7].enabled = false;

            }
            else if (index == 8)
            {
                imageScene[8].enabled = false;

            }
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            startlevel.SetActive(true);
        }
    }
}
