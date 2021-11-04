using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sticky : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "jugador")//el if se ejecuta si la plataforma colisiona con el gameobject jugador;esto busca el gameObject del jugador, ya que solo hay un objeto llamado asi, no habra problemas
        {
            collision.gameObject.transform.SetParent(transform);//esto hace que el jugador sea un hijo de la plataforma en movimiento
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "jugador")//el if se ejecuta si el jugador deja de hacer colision con la plataforma
        {
            collision.gameObject.transform.SetParent(null);//esto hace que el jugador deje de ser un hijo de la plataforma en movimiento
        }
    }
}
