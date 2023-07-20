using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSelector : MonoBehaviour
{
    public static GunSelector Instance;
    public static GameObject currentWeapon = null;

    [Header("Weapons")]
    public GameObject[] weapons = default;

    [Header("Debugging")]
    [SerializeField]private int gunIndex = default;

    private void Awake() {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
        
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
        if (!weapons[slotIndex].GetComponent<GunComponent>().pickedUp) {
            print(weapons[slotIndex].transform.name + " hasn't been picked up.");
            return;
            }
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
