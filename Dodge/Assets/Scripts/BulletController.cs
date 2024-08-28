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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // 플레이어 비활성화 //
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.TakeHit();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
