using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Animator myAnimator;

    public void UpdateAnimator (bool isWalking, int direction)
    {
        myAnimator.SetBool("Walk", isWalking);
        myAnimator.SetFloat("Direction", direction);
    }
   
}
