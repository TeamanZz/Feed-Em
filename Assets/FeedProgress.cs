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
        if (fillAmountValue >= 1)
        {
            fillAmountValue = 0;
            progressBarFilled.DOFillAmount(0, 0.5f).SetEase(Ease.InOutBack);
            progressBar.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.5f);
            CreaturesController.Instance.ChangeCreature();
        }
    }
}