using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desaplat : MonoBehaviour
{

    [SerializeField] private float tiempoDesap = 2f; //es el tiempo que se demorara la plataforma en desaparecer
    [SerializeField] private float tiempoAhora = 0f;
    public bool enabled = true;
    void Start()
    {
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoAhora += Time.deltaTime;

        if (tiempoAhora >= tiempoDesap)
        {
            tiempoAhora = 0f;
            PlatDes();
        }
    }
    private void PlatDes()
    {
        enabled = !enabled;

        foreach (Transform child in gameObject.transform)
        {
            if (child.tag != "Player")
            {
                child.gameObject.SetActive(enabled);
            }
        }
    }
}
