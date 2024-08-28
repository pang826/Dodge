using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState { Ready, Running, GameOver}
    [SerializeField] GameState curState;
    [SerializeField] TowerController[] towers;
    [SerializeField] PlayerController player;

    [Header("UI")]
    [SerializeField] GameObject readyText;
    [SerializeField] GameObject gameOverText;
    private void Start()
    {
        curState = GameState.Ready;

        // 게임씬에 있는 모든 컴포넌트 찾기
        // 단, 시간이 오래걸리는 함수이기 때문에 로딩 과정에서 사용 권장
        towers = FindObjectsOfType<TowerController>();

        player = FindObjectOfType<PlayerController>();
        player.OnDied += GameOver;

        readyText.SetActive(true);
        gameOverText.SetActive(false);
    }

    private void Update()
    {
        if(curState == GameState.Ready && Input.anyKeyDown)
        {
            GameStart();
        }
        else if(curState == GameState.GameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("DodgeScene");
        }    
    }

    public void GameStart()
    {
        readyText.SetActive(false);
        curState = GameState.Running;
        // 타워 공격 시작
        foreach(TowerController controller in towers)
        {
            controller.AttackStart();
        }
    }

    public void GameOver()
    {
        curState = GameState.GameOver;
        // 타워 공격 종료
        foreach (TowerController controller in towers)
        {
            controller.AttackStop();
        }
        readyText.SetActive(false);
        gameOverText.SetActive(true);
    }
}
