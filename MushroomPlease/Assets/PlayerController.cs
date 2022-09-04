using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player player;



    public void Update()
    {
        if (!player.canMove) return;
        
            if (Input.GetMouseButtonDown(0)&&player.iHaveHoe)
            {
                player.HoeHit();
            }
        
    }
    void FixedUpdate()
    {
        if (!player.canMove) return;
        
            float horizontalMovement = Input.GetAxisRaw("Horizontal");
            float verticalMovement = Input.GetAxisRaw("Vertical");
            player.Movement(horizontalMovement, verticalMovement);
    }


}
