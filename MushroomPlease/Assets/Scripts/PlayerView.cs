using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Animator myAnimator;

    public void UpdateAnimator (bool isWalking, int direction)
    {
        myAnimator.SetBool("Walk", isWalking);//this is for set a parameter in animator in true or false
        myAnimator.SetFloat("Direction", direction);//and this is to set a float to determine an animation in a blend tree 
    }
    public void HitHoe()
    {
        myAnimator.SetTrigger("HoeHit");
    }
  
   
}
