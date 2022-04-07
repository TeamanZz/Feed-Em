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

    public List<GameObject> availableCreaturesList = new List<GameObject>();
    public List<GameObject> generalCreaturesList = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ChangeCreature();
    }

    public void MakeCreatureAvailable(int index)
    {
        availableCreaturesList.Add(generalCreaturesList[index]);
    }

    public void ChangeCreature()
    {
        if (currentCreature != null)
        {
            currentCreature.DOMoveX(-6, 1).SetEase(Ease.InOutBack);
            currentCreature.transform.parent = null;
        }

        // currentCreature = Instantiate(creaturesList[Random.Range(0, creaturesList.Count)], creaturesSpawnPoint.position, Quaternion.Euler(-23.54f, 180, 0), creaturesContainer).transform;
        currentCreature = Instantiate(availableCreaturesList[Random.Range(0, availableCreaturesList.Count)], creaturesSpawnPoint.localPosition, Quaternion.Euler(0, 180, 0), creaturesContainer).transform;

        FeedableCreature.Instance.animator = currentCreature.GetComponent<Animator>();
        FeedableCreature.Instance.lookAnimator.HeadReference = currentCreature.transform;
        currentCreature.DOMove(creaturesContainer.position, 1).SetEase(Ease.InOutBack);
    }
}