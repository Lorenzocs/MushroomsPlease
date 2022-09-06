using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float speedSmoothed;
    public Vector3 offset;


    void FixedUpdate()
    {
        Vector3 positionCopy = player.position + offset;
        Vector3 positionSmoothed = Vector3.Lerp(transform.position, positionCopy, speedSmoothed);
        transform.position = positionSmoothed;

    }
}
