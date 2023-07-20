using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField]private Transform interactorSource = default;
    [SerializeField]private float interactRange = default;

    [SerializeField]private float syringeHealAmount = default;
    private HealthComponent healthComponent;

    private LayerMask interactableLayer;

    private void Start() {
        healthComponent = GetComponent<HealthComponent>();
        interactableLayer = LayerMask.GetMask("Interactable");
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            var ray = new Ray(interactorSource.position, interactorSource.forward);
            if (Physics.Raycast(ray, out var hit, interactRange , interactableLayer)) {

                switch(hit.collider.gameObject.tag) {
                    case "Syringe":
                        healthComponent.Heal(syringeHealAmount);
                        break;
                    case "Ammo":
                        var gunComponent = GunSelector.currentWeapon.GetComponent<GunComponent>();
                        gunComponent.addAmmo(gunComponent.maxMagazineSize);
                        break;
                    case "Shotgun":
                        print("Shotgun picked up");
                        break;
                    default:
                        break;
                }
                Destroy(hit.transform.gameObject);
            }
        }
    }
}

