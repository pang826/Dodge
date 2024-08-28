using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �ν����� â���� �����ϰų� ���� �������־ ���� ���
    [SerializeField] Rigidbody rigid;
    [SerializeField] float moveSpeed;

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        // �Է¸Ŵ����� ���� ������ �Է°��� ����
        float X = Input.GetAxisRaw("Horizontal");
        float Z = Input.GetAxisRaw("Vertical");
        // ������ٵ� : ���������� ����ϴ� ������Ʈ
        // ����ȭ : ũ�Ⱑ 1�� �ƴ� ������ ũ�⸦ 1�� ����� (normalize)
        rigid.velocity = new Vector3(X * moveSpeed, 0, Z * moveSpeed).normalized;

    }
}
