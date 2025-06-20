using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletColliderChecker : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "2DCollider")
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
