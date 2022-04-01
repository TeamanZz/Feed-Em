using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private bool canInteractWithFloor = true;
    public float dissapearDelay;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
            Destroy(gameObject, dissapearDelay);
        }
    }
}