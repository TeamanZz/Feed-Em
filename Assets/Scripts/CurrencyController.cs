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
    public Image currencyImage;

    public int currencyCount;

    private void Awake()
    {
        Instance = this;

        currencyCount = 0;
        currencyText.text = currencyCount.ToString();
    }

    public void IncreaseCurrencyCount()
    {
        currencyCount += 1;
        currencyText.text = currencyCount.ToString();
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
}