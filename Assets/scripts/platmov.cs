using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platmov : MonoBehaviour
{
    /*[SerializeField] private GameObject plat;
    [SerializeField] private Transform Inicial;
    [SerializeField] private Transform Final;
    private Transform Siguiente;
    [SerializeField] private float velocidad;
    
    void Start()
    {
        Siguiente = Final;
    }

    // Update is called once per frame
    void Update()
    {
        plat.transform.position = Vector2.MoveTowards(plat.transform.position, Siguiente.position, Time.deltaTime * velocidad);

        if (plat.transform.position == Siguiente.position)
        {
            Siguiente = Siguiente == Final ? Inicial : Final;
        }
    }
    intente usar este segun el video pero la plataforma paraba apenas llegaba a la segunda posicion QQ
    */

    [SerializeField] private GameObject[] puntos; //los brackets despues del game object crean un array, que permite poner mas de un gameobject en la variable, esto tambien permite poner mas puntos de movimiento para una plataforma
    private int PuntoActual = 0;

    [SerializeField] private float velocidad = 3f;

    private void Update()
    {
        if (Vector2.Distance(puntos[PuntoActual].transform.position, transform.position) < .1f) // Distance calcula la distancia entre dos vectores; toda la linea significa que si la plataforma y el punto actual tienen la distancia .1, entonces algo ocurrira, en este caso, el punto actual sera ahora el siguiente punto
        {
            PuntoActual++; //Esto hara que el punto actual aumente en 1 (por ejemplo no sera el 0, si no el 1)
            if (PuntoActual >= puntos.Length) //Algo diferente ocurrira si punto actual llega a ser el ultimo punto, en este caso, volvera a ser el primer punto
            {
                PuntoActual = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, puntos[PuntoActual].transform.position, Time.deltaTime * velocidad);
    }
}
