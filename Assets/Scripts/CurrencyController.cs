using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class CurrencyController : MonoBehaviour
{
    public static CurrencyController Instance;

    public TextMeshProUGUI currencyText;
    public TextMeshProUGUI shopCurrencyText;

    public Image currencyImage;
    public Image shopCurrencyImage;

    public int currencyCount;

    private void Awake()
    {
        Instance = this;

        currencyCount = 0;
        currencyText.text = currencyCount.ToString();
        shopCurrencyText.text = currencyCount.ToString();
    }

    public void DecreaseCurrencyCount(int value)
    {
        currencyCount -= value;
        currencyText.text = currencyCount.ToString();
        shopCurrencyText.text = currencyCount.ToString();
        StartCoroutine(PlayShopCurrencyAnimation());
    }

    public void IncreaseCurrencyCount()
    {
        currencyCount += 1;
        currencyText.text = currencyCount.ToString();
        shopCurrencyText.text = currencyCount.ToString();
        StartCoroutine(PlayCurrencyAnimation());

        SFX.Instance.PlayCurrencyIncrease();
    }

    public IEnumerator PlayCurrencyAnimation()
    {
        currencyText.transform.DOScale(new Vector3(1.3f, 1.3f, 1.3f), 0.2f).SetEase(Ease.OutBack);
        currencyImage.transform.DOScale(new Vector3(1.3f, 1.3f, 1.3f), 0.2f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.2f);
        currencyText.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack);
        currencyImage.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack);
    }

    public IEnumerator PlayShopCurrencyAnimation()
    {
        shopCurrencyText.transform.DOScale(new Vector3(0.7f, 0.7f, 0.7f), 0.2f).SetEase(Ease.OutBack);
        shopCurrencyImage.transform.DOScale(new Vector3(0.7f, 0.7f, 0.7f), 0.2f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.2f);
        shopCurrencyText.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack);
        shopCurrencyImage.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack);
    }
}