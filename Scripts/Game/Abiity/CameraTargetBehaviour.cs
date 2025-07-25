﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetBehaviour : MonoBehaviour
{
    public Transform target;
    public float speed = 5.0f;
    public Vector3 offset;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
