using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [SerializeField] private int amountOfMushrooms;// how many mushrooms shall be added
    [SerializeField] private Item item;// kind of item (scriptable object)
    private bool inConctactWithPlayer;

  
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hitbox"))//if mushroom is in contact with a hitbox ...
        {
            GameManager.Instance.AddItem(item, amountOfMushrooms);//add item to inventory using item type and quantity
            Destroy(gameObject);
        }
    }
  
}
