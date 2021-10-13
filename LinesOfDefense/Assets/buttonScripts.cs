using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScripts : MonoBehaviour
{

    
    public void NewGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void ExitGame()
    {
        Application.Quit();
    }

    

}
