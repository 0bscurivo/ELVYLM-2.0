using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource sonidoboton;
    public void PlayGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        
        Debug.Log("QUIT!");
        Application.Quit();
    }
    
    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }

}
