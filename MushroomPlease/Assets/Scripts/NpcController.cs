using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    [TextArea][SerializeField] private List<string> Dialogue; // here I will keep the npc messages
    private int index;// this is for know wich messagge I have to show
    private bool inContactWithPlayer;// for know if the player is in contact
    public bool iHaveTheMushrooms,myMission; //to find out if I already have the mushrooms it needs , and to know if the mission was given
    public int mushroomsRequired;// for know how many mushrooms are required

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
                        if (GameManager.Instance.items[i].name == "Mushroom" && !iHaveTheMushrooms)//I will check my inventory items to see if I have mushrooms.
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
                            if (mushroomsRequired <= 0)//if i have all the necessary mushrooms... the mission is complete
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
