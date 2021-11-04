using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //se necesita llamar para poder reiniciar el nivel cuando muera el jugador

public class Player_Life : MonoBehaviour
{
    public TimeCount time;
    private Animator anim;
    private PlayerController control;

    /*public float Invicibilidad = 2f;
    private bool esInvencible;
    private float TimerInvicibilidad;*/

    private void Start()
    {
        time = GameObject.FindWithTag("Time").GetComponent<TimeCount>();   //Obtiene el Script TimeCount del objeto Time Text
        anim = GameObject.FindWithTag("Player").GetComponent<Animator>();  //Obtiene el Animator del Player
        control = GameObject.FindWithTag("Player").GetComponent<PlayerController>();  //Obtiene el Script PlayerController del Player
    }

    private void Update()
    {       
        if (time.startingTime <= 0 ) //Revisa que el tiempo sea 0 o menor
        {
            Die();
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("trap"))
        {
            time.startingTime -= 3f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("deathtrap"))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("dement"))
        {
            time.startingTime -= 5f;
        }
    }

    private void Die()
    {
        
        anim.SetTrigger("muerte");
        control.enabled = !control.enabled;  //Desactiva el Script PlayerController en el Player para evitar que se siga moviendo al morir
        
    }

    private void Restart() // esto carga una escena, especificamente en la que estamos actualmente, es decir, este nivel, este metodo se activa dentro de la animacion de muerte
    {
        SceneManager.LoadScene("GameOver"); 
    }
}
