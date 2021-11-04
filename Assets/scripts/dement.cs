using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding; //nos deja usar el mpaquete de astar

public class dement : MonoBehaviour
{
    [SerializeField]public AIPath caminoAI;

    // Update is called once per frame
    void Update()
    {
        if(caminoAI.desiredVelocity.x >= .01f)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
        else if(caminoAI.desiredVelocity.x <= -.01f)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
    }
}
