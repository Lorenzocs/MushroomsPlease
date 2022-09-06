using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
public class UiController : MonoBehaviour
{
    public static UiController Instance { get; private set; }// A UiController instance for easy access from other scripts
    [SerializeField] private Image myImage;//to change colour in the sleep transition
    [SerializeField] private CanvasGroup myCanvasGroup;//for fade away in the sleep transition
    [SerializeField] private GameObject panelText; // this is a dialogue text panel container   
    [SerializeField] private TextMeshProUGUI dialogueText;// this is the dialogue text
    [SerializeField] private Player player;
    [SerializeField] private TextMeshProUGUI coinsText, dayText; // text of coins and days
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
        DOTween.Init(); 
        DisableText();
        DoFadeOff();
    }

    public void DoFadeOff()
    {
        myCanvasGroup.DOFade(0, 2f);
        myImage.DOColor(Color.white, 2f).OnComplete(PlayerCanMove);
    }
    public void DoFadeOffSleep()
    {

        myCanvasGroup.DOFade(0, 2f).SetDelay(1f);
        GameManager.Instance.NextDay();
        myImage.DOColor(Color.white, 2f).SetDelay(1f).OnComplete(PlayerCanMove);
    }
    public void PlayerCanMove()
    {
        player.canMove = true;
    }
    public void DoFadeOn()
    {
        myCanvasGroup.DOFade(1, 2f);
        myImage.DOColor(new Color32(44, 44, 44, 255), 2f);
    }
    public void ActiveText()
    {
        panelText.SetActive(true);
    }
    public void DisableText()
    {
        panelText.SetActive(false);
    }
    public void ChangeText(string newText)
    {
        dialogueText.text = newText;
    }
    public void ResetDialogue()
    {

        ChangeText("Press E to interact");
    }

    public void SleepTransition()
    {
        player.canMove = false;
        myCanvasGroup.DOFade(1, 2f);
        myImage.DOColor(new Color32(44, 44, 44, 255), 2f).OnComplete(DoFadeOffSleep);

    }
    public void UpdateCoinText(int coin)
    {
        coinsText.text = "Coins: " + coin;
    }
    public void UpdateDayText(int day)
    {
        dayText.text = "Day: " + day;
    }
}
