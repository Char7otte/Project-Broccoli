using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    [SerializeField]private GameObject bossHealthBar = default;
    [SerializeField]private GameObject bossEnemy = default;
    public int enemyCountInRoom3 = default;
    [SerializeField]private GameObject[] room3ItemSpawners = default;

    [SerializeField]private GameObject winScreen;
    [SerializeField]private GameObject loseScreen;

    public bool bossFightHasStarted = false;

    private GameObject player;
    

    private void Start() {
        player = GameObject.Find("Player");
        Time.timeScale = 1;
    }

    private void Update() {
        if (enemyCountInRoom3 == 0) {
            foreach (var item in room3ItemSpawners) {
                item.SetActive(true);
            }
        }

        if (bossEnemy.GetComponent<HealthComponent>().currentHealth <= 0) {
            Time.timeScale = 0;
            Cursor.visible = true;
		    Cursor.lockState = CursorLockMode.Confined;
            GameWin();
        }

        if (player.GetComponent<HealthComponent>().currentHealth <= 0) {
            Time.timeScale = 0;
            Cursor.visible = true;
		    Cursor.lockState = CursorLockMode.Confined;
            GameLose();
        }
    }

    public void StartBossFight() {
        bossFightHasStarted = true;
        bossHealthBar.SetActive(true);
        bossEnemy.GetComponent<BossEnemyControll>().enabled = true;
        bossEnemy.GetComponent<BossShoot>().enabled = true;
        bossEnemy.GetComponent<BossArenaFire>().enabled = true;
    }

    private void GameWin() {
        winScreen.SetActive(true);
    }

    private void GameLose() {
        loseScreen.SetActive(true);
    }
}
