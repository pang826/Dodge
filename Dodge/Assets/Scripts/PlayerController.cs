using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 인스펙터 창에서 참조하거나 값을 지정해주어서 쓰는 경우
    [SerializeField] Rigidbody rigid;
    [SerializeField] float moveSpeed;

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        // 입력매니저를 통해 움직임 입력값을 저장
        float X = Input.GetAxisRaw("Horizontal");
        float Z = Input.GetAxisRaw("Vertical");
        // 리지드바디 : 물리엔진을 담당하는 컴포넌트
        // 정규화 : 크기가 1이 아닌 벡터의 크기를 1로 만들기 (normalize)
        rigid.velocity = new Vector3(X * moveSpeed, 0, Z * moveSpeed).normalized;

    }
}
