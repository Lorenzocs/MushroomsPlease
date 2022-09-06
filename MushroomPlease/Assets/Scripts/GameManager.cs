using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] mushroomsRed;//type of mushrooms
    [SerializeField] private float minXToSpawn, maxXToSpawn, minYToSpawn, maxYToSpawn;//to determine the spawning of the area
    [SerializeField] private int amountOfMushrooms;//number of mushrooms to appear
    [SerializeField] private Transform containerMushrooms;//to store them 
    public List<Item> items = new List<Item>();//to store items in inventory
    public List<int> itemAmount = new List<int>(); //to find out how many items of one type there are
    public GameObject[] slots;
    public List<GameObject> mushroomsInScene= new List<GameObject>();
    [SerializeField] private NpcController npc;
    public int dayNumber;
    public int coins;
    

    public static GameManager Instance;

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
    void Start()
    {
        dayNumber = 1;
        if(mushroomsInScene.Count != 0)
        {
            foreach (var item in mushroomsInScene)//to create new mushrooms and remove old ones
            {
                Destroy(item);
            }
        }
        mushroomsInScene.Clear();
        for (int i = 0; i < amountOfMushrooms; i++)//creating new mushrooms
        {
            int randomNum = Random.Range(0, mushroomsRed.Length);
            Vector3 randomPosition = new Vector3(Random.Range(minXToSpawn, maxXToSpawn), Random.Range(minYToSpawn, maxYToSpawn), 0);
            var currentMushroom =Instantiate(mushroomsRed[randomNum], randomPosition, Quaternion.identity, containerMushrooms);
            mushroomsInScene.Add(currentMushroom);
        }
        DisplayItems();
    }

    public void DisplayItems()
    {
        for (int i = 0; i < slots.Length; i++)//resetting the slots
        {
            slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color32 (1,1,1,0);
            slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = " ";
        }
        for (int i = 0; i < items.Count; i++)//I assign to slots, image and quantity of an article type if necessary.
        {
            slots[i].transform.GetChild(0).GetComponent<Image>().color = Color.white;
            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;

            slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = Color.white;
            slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = itemAmount[i].ToString();

            slots[i].GetComponent<ItemSlot>().myItem = items[i];

        }
    }

    public void NextDay()//reset initial values and increase the day by one.
    {
        Start();
        npc.iHaveTheMushrooms = false;
        npc.myMission = false;
        npc.mushroomsRequired = 5;
        dayNumber++;
        UiController.Instance.UpdateDayText(dayNumber);
    }
    public void AddItem(Item _item,int amount)//to add an item to the inventory
    {
        if (!items.Contains(_item))//if it does not exist, I create the item and assign the quantity to it
        {
            items.Add(_item);
            itemAmount.Add(amount);

        }
        else
        {
            for (int i = 0; i < items.Count; i++)//if the item exists I only modify the quantity 
            {
                if (items[i]== _item)
                {
                    itemAmount[i] += amount;
                }
            }
        }
        DisplayItems();
    }

    public void OnDrawGizmosSelected()//this is to show the maximum and minimum points of the spawn area.
    {
        Gizmos.color = Color.red;
        var posMinX = new Vector3(minXToSpawn, containerMushrooms.position.y);
        Gizmos.DrawSphere(posMinX, 0.05f);
        var posMaxX = new Vector3(maxXToSpawn, containerMushrooms.position.y);
        Gizmos.DrawSphere(posMaxX, 0.05f);

        Gizmos.color = Color.green;
        var posMinY = new Vector3(containerMushrooms.position.x, minYToSpawn);
        Gizmos.DrawSphere(posMinY, 0.05f);
        var posMaxY = new Vector3(containerMushrooms.position.x, maxYToSpawn);
        Gizmos.DrawSphere(posMaxY, 0.05f);
    }
}
