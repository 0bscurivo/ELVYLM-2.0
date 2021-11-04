using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trayectoriaplatcirc : MonoBehaviour
{
    [SerializeField] private Transform centro;
    private float xo, yo, x, y, r, angulo, tiempo;
    // Start is called before the first frame update
    void Start()
    {
        r = 4f;
        angulo = Mathf.PI / 4;
        xo = centro.transform.position.x;
        yo = centro.transform.position.y;
        tiempo = 0f;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (tiempo >= .01f)
        {
            x = xo + r * Mathf.Cos(angulo); // x es igual al valor de xo, o sea el centro mas el radio que multiplica la funcion coseno
            y = yo + r * Mathf.Sin(angulo);// y es igual al valor de yo, o sea el centro mas el radio que multiplica la funcion seno
            angulo = (angulo - Mathf.PI / 32) % (2 * Mathf.PI); //para que sea en el sentido de las manecillas del reloj se debe restar, para el otro sentido, sumar; cada pi / 32 se mueve la plataforma, cuando llega a 360vuelve a empezar
            transform.localPosition = new Vector3(x, y, 10f); 
            tiempo = 0f;
        }
        else
        {
            tiempo += Time.deltaTime;
        }
    }
}
