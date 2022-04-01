using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CreaturesController : MonoBehaviour
{
    public static CreaturesController Instance;

    public GameObject creaturePrefab;
    public Transform creaturesContainer;
    public Transform creaturesSpawnPoint;
    public Transform currentCreature;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeCreature()
    {
        currentCreature.DOMoveX(-6, 1).SetEase(Ease.InOutBack);
        currentCreature = Instantiate(creaturePrefab, creaturesSpawnPoint.position, Quaternion.Euler(-23.54f, 180, 0), creaturesContainer).transform;
        currentCreature.DOMoveX(0, 1).SetEase(Ease.InOutBack);
    }
}