using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Food : MonoBehaviour
{
    private bool canInteractWithFloor = true;
    public float dissapearDelay;
    private Rigidbody rb;

    public List<GameObject> foodModels = new List<GameObject>();
    // public Renderer foodRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        var foodModel = foodModels[Random.Range(0, foodModels.Count)];
        // foodRenderer.material.SetTextureOffset("_MainTex", new Vector2(Random.Range(-10, 10), Random.Range(-10, 10)));
        foodModel.SetActive(true);
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack);
        foodModel.transform.DOLocalRotate(new Vector3(0, Random.Range(-200, 200), 0), 0.3f).SetEase(Ease.OutBack);
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector3.down * rb.mass, ForceMode.Acceleration);
    }

    private void Update()
    {
        if (transform.position.y <= 0 && canInteractWithFloor)
        {
            Dissapear();
            FoodSpawner.Instance.SpawnFoodAfterDelay();
            DragonsSFX.Instance.PlaySad();
        }
    }

    public void Dissapear()
    {
        if (canInteractWithFloor)
        {
            FeedableCreature.Instance.lookAnimator.SetLookTarget(null);
            canInteractWithFloor = false;
            transform.DOScale(Vector3.zero, dissapearDelay);
            Destroy(gameObject, dissapearDelay + 0.1f);
        }
    }
}