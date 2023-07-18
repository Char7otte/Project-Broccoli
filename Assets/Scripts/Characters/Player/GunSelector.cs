using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSelector : MonoBehaviour
{
    [SerializeField]private GameObject[] weapons = default;
    [Tooltip("Choose according to the alpha keys. It will subtract one when the script is run so it works correctly with Array elements.")]
    [SerializeField]private int gunIndex; //Debugging

    public static GameObject currentWeapon = null;

    private void Awake() {
        gunIndex--;
        currentWeapon = weapons[gunIndex];
        SwitchToWeaponSlot(gunIndex);
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
