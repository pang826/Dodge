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

        // ���Ӿ��� �ִ� ��� ������Ʈ ã��
        // ��, �ð��� �����ɸ��� �Լ��̱� ������ �ε� �������� ��� ����
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
        // Ÿ�� ���� ����
        foreach(TowerController controller in towers)
        {
            controller.AttackStart();
        }
    }

    public void GameOver()
    {
        curState = GameState.GameOver;
        // Ÿ�� ���� ����
        foreach (TowerController controller in towers)
        {
            controller.AttackStop();
        }
        readyText.SetActive(false);
        gameOverText.SetActive(true);
    }
}
