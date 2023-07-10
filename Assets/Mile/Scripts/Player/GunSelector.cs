using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSelector : MonoBehaviour
{
    // [SerializeField]private GameObject[] weapons;
    // private Gun[] guns;
    // private string gunSelected;

    // private void Update() {
    //     if (Input.GetKeyDown(KeyCode.1)) {
    //         guns.gunModel.SetActive(true);
    //     }
    //     if (Input.GetKeyDown(KeyCode.2)) {
    //         print("Changed to Shotgun")
    //     }
    // }

    [SerializeField]private GameObject[] weapons;

    int currentSlot = 0;
    public static GameObject currentWeapon = null;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            SwitchToWeaponSlot(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            SwitchToWeaponSlot(1);
        }
    }

    public void SwitchToWeaponSlot(int slotIndex) {
        if (slotIndex < 0 || slotIndex >= weapons.Length) return;
        disableAllWeapons();
        currentWeapon = weapons[slotIndex];
        currentWeapon.SetActive(true);
    }

    private void disableAllWeapons() {
        foreach (var weapon in weapons) {
            weapon.SetActive(false);
        }
    }
}
