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

    [SerializeField]private GameObject inputField = default;

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
                        Destroy(hit.transform.gameObject);
                        break;
                    case "Ammo":
                        var gunComponent = GunSelector.currentWeapon.GetComponent<GunComponent>();
                        gunComponent.addAmmo(gunComponent.maxMagazineSize);
                        audioManagerComponent.Play("ammo");
                        Destroy(hit.transform.gameObject);
                        break;
                    case "Shotgun":
                        WeaponPickUp(1);
                        audioManagerComponent.Play("shotgun reload");
                        Destroy(hit.transform.gameObject);
                        break;
                    case "Pistol":
                        WeaponPickUp(0);
                        audioManagerComponent.Play("pistol reload");
                        Destroy(hit.transform.gameObject);
                        break;
                    case "Key":
                        audioManagerComponent.Play("keys");
                        GameManager.Instance.keysFound += 1;
                        Destroy(hit.transform.gameObject);
                        break;
                    case "Code Trigger":
                        inputField.SetActive(true);
                        break;
                    case "KeyDoor":
                        audioManagerComponent.Play("keys");
                        Destroy(hit.transform.gameObject);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void WeaponPickUp(int slotIndex) {
        var gunSelector = GunSelector.Instance;
        var gunComponent = gunSelector.weapons[slotIndex].GetComponent<GunComponent>();
        if (gunComponent.pickedUp) {
            gunComponent.totalAmmo += gunComponent.maxMagazineSize;
        }
        else {
            gunComponent.pickedUp = true;
            gunSelector.SwitchToWeaponSlot(slotIndex);
        }
    }
}

