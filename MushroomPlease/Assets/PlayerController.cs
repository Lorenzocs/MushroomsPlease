using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
        player.Movement(horizontalMovement, verticalMovement);
    }
}
