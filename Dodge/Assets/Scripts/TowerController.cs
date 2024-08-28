using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] GameObject prefab;
    [SerializeField] float bulletShotTime;
    [SerializeField] float remainTime; // ���� �Ѿ� �򶧱��� ���� �ð�

    private void Start()
    {
        // GameObject.FindGameObjectWihtTag : ���ӿ� �ִ� �±׸� ���ؼ� Ư�� ���ӿ�����Ʈ�� ã��
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        // GetComponent : ���ӿ�����Ʈ�� �ִ� ������Ʈ ��������
        target = playerObj.GetComponent<Transform>();
        // target = playerObj.transform; �� ����
        // transform�� ���� ������Ʈ�� ������ ���ԵǾ� �ִ� ������Ʈ�̱� ����

        remainTime = bulletShotTime;
    }

    private void Update()
    {
        // ���� �Ѿ� �߻���� ���� �ð��� ��� ����
        remainTime -= Time.deltaTime;

        // ���� �Ѿ� �߻���� ���� �ð��� ���� ��� �Ѿ� �߻�
        if(remainTime <= 0 )
        {
            // �Ѿ� ���� �ڵ� �Է�
            GameObject bulletObj = Instantiate(prefab, transform.position, transform.rotation);
            BulletController bullet = bulletObj.GetComponent<BulletController>();
            bullet.SetDestination(target.position);
            // �����ð� �ٽ� ī��Ʈ
            remainTime = bulletShotTime;
        }
    }
}
