using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoe : MonoBehaviour
{
    private bool inConctactWithPlayer;

    public void Update()
    {
        if (inConctactWithPlayer&&Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inConctactWithPlayer= true;
            Player p= collision.GetComponent<Player>();
            if (p != null)
            {
                p.iHaveHoe = true;
            }
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
