using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] Button playButton, quitButton;
    [SerializeField] AudioSource sonidoboton;
    [SerializeField] Text Energy;
    public collectible collectible;
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(PlayAgain);
        quitButton.onClick.AddListener(Menu);
        Debug.Log(PlayerPrefs.GetInt("Energia"));
       
        Energy.text = "ENERGIA: " + PlayerPrefs.GetInt("Energia");
    }

    public void PlayAgain()//carga la escena del menú
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Menu()//mismo método del menú
    {
        sonidoboton.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
}
