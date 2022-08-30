using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float velocidadSuavizada;
    public Vector3 offset;


    void FixedUpdate()//4frames 
    {
        Vector3 posicionACopiar = player.position + offset;
        Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posicionACopiar, velocidadSuavizada);
        transform.position = posicionSuavizada;

    }
}
