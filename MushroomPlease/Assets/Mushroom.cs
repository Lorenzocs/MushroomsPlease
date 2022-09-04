using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [SerializeField] private int amountOfMushrooms;
    [SerializeField] private Item item;
    private bool inConctactWithPlayer;

  
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hitbox"))
        {
            GameManager.Instance.AddItem(item, amountOfMushrooms);
            Destroy(gameObject);
        }
    }
  
}
