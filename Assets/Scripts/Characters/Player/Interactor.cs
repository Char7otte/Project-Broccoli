using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [Header("Raycasting")]
    [SerializeField]private Transform cameraPosition = default;
    [SerializeField]private float interactRange = default;
    private LayerMask interactableLayer;

    [Header("Syringe & Healing")]
    [SerializeField]private float syringeHealAmount = default;
    private HealthComponent healthComponent;

    private AudioManagerComponent audioManagerComponent;

    private void Start() {
        healthComponent = GetComponent<HealthComponent>();
        interactableLayer = LayerMask.GetMask("Interactable");
        audioManagerComponent = GetComponent<AudioManagerComponent>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            var ray = new Ray(cameraPosition.position, cameraPosition.forward);
            if (Physics.Raycast(ray, out var hit, interactRange , interactableLayer)) {

                switch(hit.collider.gameObject.tag) {
                    case "Syringe":
                        healthComponent.Heal(syringeHealAmount);
                        audioManagerComponent.Play("heal");
                        break;
                    case "Ammo":
                        var gunComponent = GunSelector.currentWeapon.GetComponent<GunComponent>();
                        gunComponent.addAmmo(gunComponent.maxMagazineSize);
                        audioManagerComponent.Play("ammo");
                        break;
                    case "Shotgun":
                        WeaponPickUp(1);
                        audioManagerComponent.Play("shotgun");
                        break;
                    case "Pistol":
                        WeaponPickUp(0);
                        audioManagerComponent.Play("pistol");
                        break;
                    case "Key":
                        audioManagerComponent.Play("keys");
                        GameManager.Instance.keyPickedUp = true;
                        PlayerDialogueManager.Instance.KeyFound();
                        break;
                    default:
                        break;
                }
                Destroy(hit.transform.gameObject);
            }
        }
    }

    private void WeaponPickUp(int slotIndex) {
        var gunSelector = GunSelector.Instance;
        print(gunSelector.weapons[slotIndex].transform.name + " picked up.");
        gunSelector.weapons[slotIndex].GetComponent<GunComponent>().pickedUp = true;
        gunSelector.SwitchToWeaponSlot(slotIndex);
    }
}

