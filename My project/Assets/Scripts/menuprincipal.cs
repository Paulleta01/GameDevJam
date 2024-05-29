using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuprincipal : MonoBehaviour
{
   public void PlayGame()
{
    Debug.Log("Loading next scene...");
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}

public void QuitGame()
{
    Debug.Log("Quitting game...");
    Application.Quit();
}
}