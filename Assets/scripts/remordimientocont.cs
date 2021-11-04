using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class remordimientocont : MonoBehaviour
{
    [SerializeField] private int caminoActual = 0;
    [SerializeField] private Vector2[] caminos;
    [SerializeField] private float velocidad = 4;

    private Animator animded;

    private SpriteRenderer sprite;
    private GameObject rem;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animded = GetComponent<Animator>();
        rem = GameObject.FindWithTag("remord");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, caminos[caminoActual], velocidad * Time.deltaTime);
        if (transform.position.x == caminos[caminoActual].x && transform.position.y == caminos[caminoActual].y) //si el remordimiento llega al camino actual, esto se activa
        {
            caminoActual++; //ahora el camino actual es el siguiente, es decir, ahora se dirigira alla

            if (caminoActual >= caminos.Length) //si se llega al ultimo camino,
            {
                caminoActual = 0;// vuelve al primero
            }
        }

        if (caminos[caminoActual].x > transform.position.x)
        {
            sprite.flipX = true;
        }
        else if (caminos[caminoActual].x < transform.position.x)
        {
            sprite.flipX = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Ded();
        }
    }

    private void Ded()
    {
        animded.SetTrigger("ded");
        rem.SetActive(false);
    }
}
