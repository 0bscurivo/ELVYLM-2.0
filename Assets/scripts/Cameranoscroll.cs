using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameranoscroll : MonoBehaviour
{
    private Transform camera;
    private GameObject player;
    private Rigidbody2D rb;
    private float cameraz;
    private float camerax;// para seguir la posicion en x y z de la camara.
    private float jumpy;
    private Vector3 camera_pos_p; // se utiliza para mantener la posicion de la camara
    
    void Start()
    {
        camera = GetComponent<Transform>();
        player = GameObject.Find("jugador");
        rb = player.GetComponent<Rigidbody2D>();
        camerax = camera.position.x;
        cameraz = camera.position.z;
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Floor(rb.velocity.y) == 0) //revisa si esta saltando y si el piso tiene velocidad en 0; la fisica del juego esta raro? pero no sabia porque fcjan, entonces revisa que los numeros de la velocidad esten cerca a 0 y los reconoce como 0
        {
            jumpy = camera.position.y;//si esto ocurre la camara para en esa posicion
        }

        else if (rb.velocity.y < 0) // cuando la velocidad en y es menor que 0 la camara para en esa posicion tambien
        {
            jumpy = camera.position.y;
        }

        if (rb.position.y > jumpy)
        {
            camera_pos_p.x = camerax;
            camera_pos_p.z = cameraz;//estas dos estan para que no cambie x ni z mientras la camara se  mueve
            camera_pos_p.y = rb.position.y;
            camera.position = camera_pos_p;//esto establece camera_pos_p como la nueva posicion de la camara, la cual no cambia en z ni x, pero si en y
        }
    }
}
