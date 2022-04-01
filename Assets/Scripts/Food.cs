using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Food : MonoBehaviour
{
    private bool canInteractWithFloor = true;
    public float dissapearDelay;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, 0.3f);
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector3.down * rb.mass, ForceMode.Acceleration);
    }

    private void Update()
    {
        if (transform.position.y <= 0 && canInteractWithFloor)
        {
            canInteractWithFloor = false;
            FoodSpawner.Instance.SpawnFoodAfterDelay();
        }
    }

    public void Dissapear()
    {
        if (canInteractWithFloor)
        {
            canInteractWithFloor = false;
            transform.DOScale(Vector3.zero, dissapearDelay);
            Destroy(gameObject, dissapearDelay);
        }
    }
}