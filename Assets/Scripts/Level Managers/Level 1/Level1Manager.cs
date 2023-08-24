using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Level1Manager : MonoBehaviour
{
    public bool hasPlayerApproachedChurch = false;
    public bool hasPlayerPickedUpKey = false;
    private bool playerHealthDecreaseTriggered = false;
    public bool churchIsUnlocked = true;

    [SerializeField]private GameObject churchDoor = default;
    private bool triggered = default;

    private void Start() {
        PlayerDialogueManager.Instance.StartOfLevel1();
        GunSelector.Instance.weapons[0].GetComponent<GunComponent>().remainingBulletsInMagazine = 0;
        // var gunSelector = GunSelector.Instance;
        // var gunComponent = gunSelector.weapons[slotIndex].GetComponent<GunComponent>();
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

        if (GameManager.Instance.playerHasDied && !triggered) {
            Cursor.visible = true;
		    Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void ChurchUnlocked() {
        churchIsUnlocked = true;
        churchDoor.SetActive(false);
        AudioManagerMaster.Instance.Play("door break");
    }
}
