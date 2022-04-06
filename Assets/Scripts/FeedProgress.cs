using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FeedProgress : MonoBehaviour
{
    public static FeedProgress Instance;

    public Transform progressBar;
    public float fillPerFeed;
    private float fillAmountValue = 0;

    public List<ParticleSystem> particlesOnFeed = new List<ParticleSystem>();

    private void Awake()
    {
        Instance = this;
    }

    public Image progressBarFilled;

    [ContextMenu("increase")]
    public void IncreaseProgressBarValue()
    {
        fillAmountValue += fillPerFeed;
        progressBarFilled.DOFillAmount(fillAmountValue, 0.5f).SetEase(Ease.OutBack);


        var currentDragon = FeedableCreature.Instance.transform.GetChild(0);

        currentDragon.DOScale(new Vector3(currentDragon.transform.localScale.x + 0.05f, currentDragon.transform.localScale.y + 0.05f, currentDragon.transform.localScale.z + 0.05f), 0.2f);
        if (fillAmountValue >= 1)
        {
            fillAmountValue = 0;
            progressBarFilled.DOFillAmount(0, 0.5f).SetEase(Ease.InOutBack);
            progressBar.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.5f);

            CreaturesController.Instance.ChangeCreature();
            CurrencyController.Instance.IncreaseCurrencyCount();
            DragonsSFX.Instance.ChangePitchValue();
        }

        for (int i = 0; i < particlesOnFeed.Count; i++)
        {
            particlesOnFeed[i].Play();
        }
    }
}