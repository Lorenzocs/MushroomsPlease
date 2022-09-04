using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Hoe : MonoBehaviour
{
    private bool inConctactWithPlayer;
    [SerializeField] private Item item;

    public void Start()
    {
        DOTween.Init();
        Enlarge();
    }
    public void Update()
    {
        if (inConctactWithPlayer && Input.GetKeyDown(KeyCode.E))
        {
            GameManager.Instance.AddItem(item,1);
            InventorySystem.Instance.UpdateTheInventory(InventorySystem.Instance.index);
            Destroy(gameObject);
        }
    }
    void Enlarge()
    {
        transform.DOScale(1f, 0.5f).SetEase(Ease.Linear).OnComplete(Shrink);
    }
    void Shrink()
    {
        transform.DOScale(0.7f, 0.5f).SetEase(Ease.Linear).OnComplete(Enlarge);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inConctactWithPlayer = true;
            Player p = collision.GetComponent<Player>();
           /* if (p != null)
            {
                p.iHaveHoe = true;

            }*/
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
