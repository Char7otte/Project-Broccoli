using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    [SerializeField]private GameObject bossHealthBar = default;
    [SerializeField]private GameObject bossEnemy = default;
    public int enemyCountInRoom3 = default;
    [SerializeField]private GameObject[] room3ItemSpawners = default;

    public bool bossFightHasStarted = false;

    private void Update() {
        if (enemyCountInRoom3 == 0) {
            foreach (var item in room3ItemSpawners) {
                item.SetActive(true);
            }
        }
    }

    public void StartBossFight() {
        bossFightHasStarted = true;
        bossHealthBar.SetActive(true);
        bossEnemy.GetComponent<BossEnemyControll>().enabled = true;
        bossEnemy.GetComponent<BossShoot>().enabled = true;
        bossEnemy.GetComponent<BossArenaFire>().enabled = true;
    }
}
