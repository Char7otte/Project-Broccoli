using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    [SerializeField]private GameObject bossHealthBar = default;
    [SerializeField]private GameObject bossEnemy = default;
    public bool bossFightHasStarted = false;

    public void StartBossFight() {
        bossFightHasStarted = true;
        bossHealthBar.SetActive(true);
        bossEnemy.GetComponent<BossEnemyControll>().enabled = true;
        bossEnemy.GetComponent<BossShoot>().enabled = true;
    }
}
