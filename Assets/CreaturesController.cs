using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CreaturesController : MonoBehaviour
{
    public static CreaturesController Instance;

    public Transform creaturesContainer;
    public Transform creaturesSpawnPoint;
    public Transform currentCreature;

    public FeedableCreature feedableCreature;

    public List<GameObject> creaturesList = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ChangeCreature();
    }

    public void ChangeCreature()
    {
        if (currentCreature != null)
        {
            currentCreature.DOMoveX(-6, 1).SetEase(Ease.InOutBack);
            currentCreature.transform.parent = null;
        }

        currentCreature = Instantiate(creaturesList[Random.Range(0, creaturesList.Count)], creaturesSpawnPoint.position, Quaternion.Euler(-23.54f, 180, 0), creaturesContainer).transform;
        currentCreature.DOMoveX(0, 1).SetEase(Ease.InOutBack);

        feedableCreature.animator = currentCreature.GetComponent<Animator>();
    }
}