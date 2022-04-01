using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackGroundDragon : MonoBehaviour
{
    public Vector3 endPoint;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(endPoint, 25);
    }
}