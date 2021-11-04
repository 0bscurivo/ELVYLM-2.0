using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class menupausa : MonoBehaviour
{
    public static bool EstaEnPausa = false; // esta variable va a revisar si el juego esta o no en pausa

    public GameObject menuPausaUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (EstaEnPausa)
            {
                Continuar();
            }
            else
            {
                Pausa();
            }
        }
    }

    public void Continuar()
    {
        menuPausaUI.SetActive(false); //desactiva el menu de pausa creado en el canvas
        Time.timeScale = 1f; //vuelve a correr el tiempo dentro del juego
        EstaEnPausa = false;
    }

    void Pausa()
    {
        menuPausaUI.SetActive(true); //activa el menu de pausa creado en el canvas
        Time.timeScale = 0f; //para el tiempo dentro del juego
        EstaEnPausa = true;
    }

    public void Salir()
    {
        Debug.Log("Saliendo");
        SceneManager.LoadScene("Menu"); //Como esto no se puede probar dentro del editor, dejamos el debug para ver si el boton si funciona
    }
}
