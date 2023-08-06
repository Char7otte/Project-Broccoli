using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            if (GameManager.Instance.keyPickedUp == false) return;

            DoorHasBeenTriggered();
        }
    }

    private void DoorHasBeenTriggered() {
        print("Door has been unlocked.");
        GameObject[] enemySpawners = GameObject.FindGameObjectsWithTag("Enemy Spawner");
        foreach (var enemySpawner in enemySpawners) {
            enemySpawner.GetComponent<EnemySpawner>().SpawnEnemy();
        }
    }
}
