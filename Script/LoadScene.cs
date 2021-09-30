using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    
    //public Gamemaster gm;
  public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void StartScene()
    {
        SceneManager.LoadScene("Cutscene1");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void EndcutScene()
    {
        SceneManager.LoadScene("Cutscene2");
        
    }
    public void StartGame2()
    {
        GameObject.Find("GameMaste").GetComponent<Gamemaster>().lastCheckPointPos = new Vector3(5.64f,12.68f, 0.8f);
        SceneManager.LoadScene("Level2");
       
    }
    public void EndcutScene3()
    {
        SceneManager.LoadScene("Cutscene3");
    }
    public void StartGame3()
    {
        GameObject.Find("GameMaste").GetComponent<Gamemaster>().lastCheckPointPos = new Vector3(102.557f, 16.21f, -3.564f);
        SceneManager.LoadScene("Level3");
    }

}
