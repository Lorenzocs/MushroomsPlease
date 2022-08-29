using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private PlayerView playerView;
    private int direction;
    public void Movement(float horizontalMovement, float verticalMovement)
    {
        bool isWalking = false;
        if (verticalMovement != horizontalMovement)
        {
            isWalking = true;
            if (verticalMovement != 0)
            {

                if (verticalMovement < 0)
                {
                    direction = 0;
                }
                else
                {
                    direction = 1;
                }
                transform.position += transform.up * verticalMovement * speed * Time.deltaTime;
            }
            else if (horizontalMovement != 0)
            {

                if (horizontalMovement < 0)
                {
                    direction = 2;
                }
                else
                {
                    direction = 3;
                }
                transform.position += transform.right * horizontalMovement * speed * Time.deltaTime;
            }
        }
        playerView.UpdateAnimator(isWalking, direction);
       
    }
}
