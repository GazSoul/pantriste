
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlMenuScript : MonoBehaviour
{
 public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

     public void exit()
    {
        Application.Quit();
    }
}
