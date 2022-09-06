using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public GameObject[] Slots;
    public int index;
    public ItemSlot currentSelected;
    [SerializeField]private Player myPlayer;
    public static InventorySystem Instance;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            index -= 1;
            if (index < 0)
            {
                index = Slots.Length-1;
            }
            UpdateTheInventory(index);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
           
            index += 1;
            if (index >= Slots.Length)
            {
                index = 0;
            }
            UpdateTheInventory(index);
        }

    }
    public void UpdateTheInventory(int currentIndex)
    {
        myPlayer.iHaveHoe = false;
        for (int i = 0; i < Slots.Length; i++)
        {
            if (i == currentIndex)
            {
                Slots[i].transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);//for little feedback 
                currentSelected = Slots[i].GetComponent<ItemSlot>();
                if (currentSelected.myItem != null)
                {

                    if (currentSelected.myItem.name == "Hoe")//this is to know if the player has selected a hoe.
                    {
                        myPlayer.iHaveHoe = true;
                    }
                 
                }
            }
            else
            {
                Slots[i].transform.localScale = Vector3.one;

            }

        }
    }
}
