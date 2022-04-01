using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedableCreature : MonoBehaviour
{
    public static FeedableCreature Instance;

    public Animator animator;

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        Food food;
        if (other.TryGetComponent<Food>(out food))
        {
            PlayEatAnimation();
            FeedProgress.Instance.IncreaseProgressBarValue();
            food.Dissapear();
            FoodSpawner.Instance.SpawnFoodAfterDelay();
        }
    }

    private void PlayEatAnimation()
    {
        animator.Play("Eat 0", 0, 0.1f);
    }
}