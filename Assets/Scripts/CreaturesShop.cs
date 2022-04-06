using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreaturesShop : MonoBehaviour
{
    public GameObject shopPanel;
    public int lastCreaturePrice = 3;

    public Button buyRandomCreatureButton;

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
        lastCreaturePrice += 2;
    }
}