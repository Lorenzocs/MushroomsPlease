using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
public class UiController : MonoBehaviour
{
    public static UiController Instance { get; private set; }
    [SerializeField] private Image myImage;
    [SerializeField] private CanvasGroup myCanvasGroup;
    [SerializeField] private GameObject panelText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DoFadeOff()
    {
        myCanvasGroup.DOFade(0, 2f);
        myImage.DOColor(Color.white,2f);
    }
    public void DoFadeOn()
    {
        myCanvasGroup.DOFade(1, 2f);
        myImage.DOColor(new Color32(44,44,44,255), 2f);
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
}