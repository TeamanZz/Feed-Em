using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CreatureItem : MonoBehaviour
{
    public int index;
    public ItemState itemState;

    public GameObject lockedObject;
    public GameObject unlockedObject;

    public ParticleSystem particle;

    public void UnlockCreature(int index)
    {
        lockedObject.SetActive(false);
        unlockedObject.transform.localScale = Vector3.one * 0.7f;
        unlockedObject.SetActive(true);
        unlockedObject.transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.InOutBack);
        itemState = ItemState.Unlocked;
        particle.Play();
    }

    public enum ItemState
    {
        Locked,
        Unlocked
    }
}
