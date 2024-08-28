using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] GameObject prefab;
    [SerializeField] float bulletShotTime;
    [SerializeField] float remainTime; // 다음 총알 쏠때까지 남은 시간

    private void Start()
    {
        // GameObject.FindGameObjectWihtTag : 게임에 있는 태그를 통해서 특정 게임오브젝트를 찾기
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        // GetComponent : 게임오브젝트에 있는 컴포넌트 가져오기
        target = playerObj.GetComponent<Transform>();
        // target = playerObj.transform; 과 같다
        // transform은 게임 오브젝트에 무조건 포함되어 있는 컴포넌트이기 때문

        remainTime = bulletShotTime;
    }

    private void Update()
    {
        // 다음 총알 발사까지 남은 시간을 계속 차감
        remainTime -= Time.deltaTime;

        // 다음 총알 발사까지 남은 시간이 없는 경우 총알 발사
        if(remainTime <= 0 )
        {
            // 총알 생성 코드 입력
            GameObject bulletObj = Instantiate(prefab, transform.position, transform.rotation);
            BulletController bullet = bulletObj.GetComponent<BulletController>();
            bullet.SetDestination(target.position);
            // 남은시간 다시 카운트
            remainTime = bulletShotTime;
        }
    }
}
