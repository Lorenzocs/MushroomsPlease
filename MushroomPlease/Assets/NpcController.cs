using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    [TextArea][SerializeField] private List<string> Dialogue;
    private int index;
    private bool inContactWithPlayer;


    public void Update()
    {
        if (inContactWithPlayer)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
               
              
                if(index >= Dialogue.Count)
                {
                    index = 0;
                    UiController.Instance.ResetDialogue();
                    return;
                }
                UiController.Instance.ChangeText(Dialogue[index]);
                index++;

            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inContactWithPlayer = true;
            UiController.Instance.ActiveText();
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inContactWithPlayer = true;
            UiController.Instance.DisableText();
            UiController.Instance.ResetDialogue();
        }
    }
    
}
