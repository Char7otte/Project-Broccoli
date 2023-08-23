using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    public bool hasPlayerApproachedChurch = false;
    public bool hasPlayerPickedUpKey = false;
    private bool playerHealthDecreaseTriggered = false;

    private void Start() {
        PlayerDialogueManager.Instance.StartOfLevel1();
    }

    private void Update() {
        if (!playerHealthDecreaseTriggered) {
            playerHealthDecreaseTriggered = true;
            var player = GameObject.FindGameObjectWithTag("Player");
            var playerHealthComponent = player.GetComponent<HealthComponent>();
            playerHealthComponent.currentHealth = playerHealthComponent.maxHealth / 10;
        }

        if (GameManager.Instance.keysFound > 0 && !hasPlayerPickedUpKey) {
            hasPlayerPickedUpKey = true;
            PlayerDialogueManager.Instance.KeyFound();
        }
    }
}
