using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    private bool inConctactWithPlayer;
    public void Update()
    {
        if (inConctactWithPlayer && Input.GetKeyDown(KeyCode.E))
        {
            UiController.Instance.DisableText();
            UiController.Instance.SleepTransition();
            GameManager.Instance.missionOfTheDay = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inConctactWithPlayer = true;
            UiController.Instance.ResetDialogue();
            UiController.Instance.ActiveText();
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inConctactWithPlayer = false;
            UiController.Instance.DisableText();
            UiController.Instance.ResetDialogue();
        }
    }
}
