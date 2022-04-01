using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FoodSpawner : MonoBehaviour
{
    public static FoodSpawner Instance;

    public Transform foodSpawnPoint;
    public GameObject foodPrefab;
    public ParticleSystem spawnParticles;
    public float delayBetweenFoodSpawn;

    private void Awake()
    {
        Instance = this;
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
        GameObject newFood = Instantiate(foodPrefab, foodSpawnPoint);
        // spawnParticles.Play();
    }
}