using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private PlayerView playerView;
    private int direction; //this is to know which animation to apply 
    public bool iHaveHoe, canMove;// this is to know if the player has selected a Hoe and to know if the player can move. 
    [SerializeField] private GameObject hitBox;//this is a hit box for detecting mushrooms
 

    public void Movement(float horizontalMovement, float verticalMovement)
    {
        bool isWalking = false;//if nothing happens , the player is not moving
        if (verticalMovement != horizontalMovement)
        {
            isWalking = true;// the player is moving
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
        playerView.UpdateAnimator(isWalking, direction);// update the animation in player view
       
    }
    public void HoeHit()
    {
        playerView.HitHoe(); // call a trigger in animator to trigger the animation
        GameObject box=  Instantiate(hitBox, transform.position, transform.rotation);//and spawn a hit box in the player position
        Destroy(box, 0.1f); //will be destroyed in 0.1 seconds
    }
}
