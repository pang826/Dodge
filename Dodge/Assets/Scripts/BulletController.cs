using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] Rigidbody rigid;
    [SerializeField] Vector3 destination;
    [SerializeField] float speed;

    private void Start()
    {
        transform.LookAt(destination);
        
        rigid.velocity = transform.forward * speed;
        
    }
    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
    }
}
