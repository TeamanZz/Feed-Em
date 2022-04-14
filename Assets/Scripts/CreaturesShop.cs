using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class CreaturesShop : MonoBehaviour
{
    public GameObject shopPanel;
    public int lastCreaturePrice = 3;

    public Button buyRandomCreatureButton;

    public TextMeshProUGUI buttonPriceText;

    [SerializeField] private List<CreatureItem> generalCreaturesItems = new List<CreatureItem>();

    private void Awake()
    {
        // lockedCreaturesItems. = generalCreaturesItems;
    }

    private void Start()
    {
        UpdateLastPriceText();
    }

    private void FixedUpdate()
    {
        if (CurrencyController.Instance.currencyCount >= lastCreaturePrice)
            buyRandomCreatureButton.enabled = true;
        else
            buyRandomCreatureButton.enabled = false;
    }

    public void ToggleShopPanel()
    {
        shopPanel.SetActive(!shopPanel.activeSelf);
    }

    public void BuyRandomCreature()
    {
        CurrencyController.Instance.DecreaseCurrencyCount(lastCreaturePrice);
        lastCreaturePrice = 2;
        UpdateLastPriceText();

        List<CreatureItem> lockedCreatures = generalCreaturesItems.FindAll(x => x.itemState == CreatureItem.ItemState.Locked);
        int newCreatureIndex = Random.Range(0, lockedCreatures.Count);
        UnlockNewCreature(lockedCreatures[newCreatureIndex].index);
        UnlockCreatureUI(lockedCreatures[newCreatureIndex].index);

        if (lockedCreatures.Count == 1)
        {
            buyRandomCreatureButton.gameObject.SetActive(false);
        }
        StartCoroutine(PlayButtonAnimation());
        SFX.Instance.PlayBuy();
    }

    private IEnumerator PlayButtonAnimation()
    {
        buyRandomCreatureButton.transform.DOScale(Vector3.one * 0.8f, 0.1f);
        yield return new WaitForSeconds(0.1f);
        buyRandomCreatureButton.transform.DOScale(Vector3.one, 0.1f);
    }

    private void UpdateLastPriceText()
    {
        buttonPriceText.text = "Buy New Dragon " + lastCreaturePrice;
    }

    private void UnlockNewCreature(int index)
    {
        CreaturesController.Instance.MakeCreatureAvailable(index);
    }

    private void UnlockCreatureUI(int index)
    {
        generalCreaturesItems[index].UnlockCreature(index);
    }
}