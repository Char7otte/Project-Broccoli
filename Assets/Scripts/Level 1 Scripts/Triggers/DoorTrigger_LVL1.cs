using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger_LVL1 : MonoBehaviour
{
    private AudioManagerComponent audioManagerComponent;

    private bool firstTriggered = default;
    private bool secondTriggered = default;

    private void Start() {
        audioManagerComponent = GetComponent<AudioManagerComponent>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            PlayerEnteredTrigger();
        }
    }

    private void PlayerEnteredTrigger() {
        if (GameManager.Instance.keyPickedUp == false && !firstTriggered) PlayerDoesNotHaveKey();
        else if (GameManager.Instance.keyPickedUp && !secondTriggered) PlayerHasKey();
    }

    private void PlayerDoesNotHaveKey() {
        audioManagerComponent.Play("door locked");
        PlayerDialogueManager.Instance.ChurchDoorFirstApproach();
        firstTriggered = true;
    }

    private void PlayerHasKey() {
        audioManagerComponent.Play("door unlocked");
        PlayerDialogueManager.Instance.ChurchDoorUnlocked();
        secondTriggered = true;

        GameObject[] enemySpawners = GameObject.FindGameObjectsWithTag("Enemy Spawner");
        foreach (var enemySpawner in enemySpawners) {
            enemySpawner.GetComponent<EnemySpawner>().SpawnEnemy();
        }
    }
}
