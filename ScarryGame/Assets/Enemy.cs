using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float distanceOfOneStep = 1;

    void Update()
    {
        var distance = Vector3.Distance(transform.position, target.position);

        if (distance >= 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, distanceOfOneStep);
        }
    }
}
