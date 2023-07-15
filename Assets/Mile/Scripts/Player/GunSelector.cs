using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSelector : MonoBehaviour
{
    [SerializeField]private GameObject[] weapons;

    public static GameObject currentWeapon = null;

    private void Awake() {
        currentWeapon = weapons[0];
        SwitchToWeaponSlot(0);
    }

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
        enableWeapon(slotIndex);
    }

    private void disableAllWeapons() {
        foreach (var weapon in weapons) {
            weapon.SetActive(false);
        }
    }

    private void enableWeapon(int slotIndex) {
        currentWeapon = weapons[slotIndex];
        currentWeapon.SetActive (true);
    }
}
