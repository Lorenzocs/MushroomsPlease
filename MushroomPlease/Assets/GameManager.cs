using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] mushroomsRed;
    [SerializeField] private float minXToSpawn, maxXToSpawn, minYToSpawn, maxYToSpawn;
    [SerializeField] private int amountOfMushrooms;
    [SerializeField] private Transform containerMushrooms;
    public List<Item> items = new List<Item>();
    public List<int> itemAmount = new List<int>();
    public GameObject[] slots;
    public List<GameObject> mushroomsInScene= new List<GameObject>();

    public int dayNumber;
    public int coins;
    public bool missionOfTheDay;

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
        mushroomsInScene.Clear();
        for (int i = 0; i < amountOfMushrooms; i++)
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
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color32 (1,1,1,0);


           
            slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = " ";
        }
        for (int i = 0; i < items.Count; i++)
        {
            slots[i].transform.GetChild(0).GetComponent<Image>().color = Color.white;
            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;

            slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = Color.white;
            slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = itemAmount[i].ToString();



        }
    }

    public void AddItem(Item _item,int amount)
    {
        if (!items.Contains(_item))
        {
            items.Add(_item);
            itemAmount.Add(amount);

        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i]== _item)
                {
                    itemAmount[i] += amount;
                }
            }
        }
        DisplayItems();
    }

    public void OnDrawGizmosSelected()
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
