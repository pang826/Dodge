using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] Vector3 destination;
    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
    }
}
