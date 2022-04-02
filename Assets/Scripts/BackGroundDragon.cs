using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackGroundDragon : MonoBehaviour
{
    public Vector3 endPoint;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        StartCoroutine(RestartFly());
    }

    private IEnumerator RestartFly()
    {
        transform.DOMove(endPoint, 25);
        yield return new WaitForSeconds(25);
        transform.position = startPos;
        yield return RestartFly();
    }
}