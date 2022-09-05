using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    [TextArea][SerializeField] private List<string> Dialogue;
    private int index;
    private bool inContactWithPlayer;
    public bool iHaveTheMushrooms,myMission;
    public int mushroomsRequired;

    private Player player;


    public void Update()
    {
        if (inContactWithPlayer)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                if (!myMission)
                {

                    if (index >= Dialogue.Count)
                    {
                        index = 0;
                        UiController.Instance.ResetDialogue();
                        myMission = true;
                        return;
                    }
                    UiController.Instance.ChangeText(Dialogue[index]);
                    index++;
                }
                else
                {
                 
                    for (int i = 0; i < GameManager.Instance.items.Count; i++)
                    {
                        if (GameManager.Instance.items[i].name == "Mushroom" && !iHaveTheMushrooms)
                        {
                            int aux = GameManager.Instance.itemAmount[i] - mushroomsRequired;
                            if (aux <= 0)
                            {
                                aux = 0;
                            }
                            mushroomsRequired -= GameManager.Instance.itemAmount[i];
                            if (mushroomsRequired <= 0)
                            {
                                mushroomsRequired = 0;
                            }

                            GameManager.Instance.itemAmount[i] = aux;
                            if (aux <= 0)
                            {

                                GameManager.Instance.items.Remove(GameManager.Instance.items[i]);
                                GameManager.Instance.itemAmount.Remove(GameManager.Instance.itemAmount[i]);
                            }
                            GameManager.Instance.DisplayItems();
                            if (mushroomsRequired <= 0)
                            {
                                iHaveTheMushrooms = true;
                                GameManager.Instance.coins += 100;
                                UiController.Instance.UpdateCoinText(GameManager.Instance.coins);
                            }

                        }
                    }
                        if (iHaveTheMushrooms)
                        {
                            UiController.Instance.ChangeText("Thank you! You can sleep, see you tomorrow.");
                        }
                        else
                        {
                            UiController.Instance.ChangeText("I need " + mushroomsRequired + " mushroom more!");
                        }
                }

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
