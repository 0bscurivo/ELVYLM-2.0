using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    //[SerializeField] private float startingTime;

    public float startingTime;

    private Text timeText;

    void Start()
    {
        timeText = GetComponent<Text>();
    }

    void Update()
    {
        startingTime -= Time.deltaTime;

        timeText.text = "" + Mathf.Round(startingTime);

        if (startingTime <= 0f) startingTime = 0f; //Cuando el tiempo llega a 0 el If hace que no pueda ser menor
    }

}
