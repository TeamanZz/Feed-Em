using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using FIMSpace.FLook;

public class FoodSpawner : MonoBehaviour
{
    public static FoodSpawner Instance;

    public Transform foodSpawnPoint;
    public GameObject foodPrefab;
    public ParticleSystem spawnParticles;
    public float delayBetweenFoodSpawn;
    public GameObject lastFood;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnFood();
    }

    public void SpawnFoodAfterDelay()
    {
        StartCoroutine(IESpawnFood());
    }

    private IEnumerator IESpawnFood()
    {
        yield return new WaitForSeconds(delayBetweenFoodSpawn);
        SpawnFood();
    }

    private void SpawnFood()
    {
        lastFood = Instantiate(foodPrefab, foodSpawnPoint);
        FeedableCreature.Instance.lookAnimator.SetLookTarget(lastFood.transform);

        // spawnParticles.Play();
    }
}