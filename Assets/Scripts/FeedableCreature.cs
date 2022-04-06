using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FIMSpace.FLook;

public class FeedableCreature : MonoBehaviour
{
    public static FeedableCreature Instance;

    public FIMSpace.FLook.FLookAnimator lookAnimator;
    public Animator animator;

    private void Awake()
    {
        Instance = this;
    }

    private void FixedUpdate()
    {
        if (animator != null && FoodSpawner.Instance.lastFood != null)
        {
            // Debug.Log(FoodSpawner.Instance.lastFood.transform.position);
            float value = (FoodSpawner.Instance.lastFood.transform.position.z + 3.5f) / (-0.5f + 3.5f);
            animator.SetFloat("Blend", value, 0.05f, Time.deltaTime);
        }
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

            DragonsSFX.Instance.PlayChewing();
        }
    }

    private void PlayEatAnimation()
    {
        animator.Play("Eat 0", 0, 0.1f);
    }
}