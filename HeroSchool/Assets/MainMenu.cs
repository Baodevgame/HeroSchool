using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GoToRegister()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToLogIn()
    {
        SceneManager.LoadScene(2);
    }
    public void GoToPlayGame()
    {
        SceneManager.LoadScene(3);
    }
}
