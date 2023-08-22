using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{   
    [Header("Player")]
    private GameObject player = default;
    private HealthComponent healthComponent;

    [Header("Health")]
    [SerializeField]private Image healthbarImage = default;
    [SerializeField]private TextMeshProUGUI healthText = default;

    [Header("Ammo")]
    [SerializeField]private TextMeshProUGUI ammoText = default;

    private void Start() {
        player = GameObject.Find("PlayerCharacter");
        healthComponent = player.GetComponent<HealthComponent>();
    }

    private void Update() {
        var currentHealth = healthComponent.currentHealth;
        var maxHealth = healthComponent.maxHealth;
        healthbarImage.fillAmount = currentHealth / maxHealth;
        healthText.SetText("Health: " + currentHealth);

        var gunComponent = GunSelector.currentWeapon.GetComponent<GunComponent>();  //Must be constantly updated as the player can change weapon.
        var currentAmmo = gunComponent.remainingBulletsInMagazine;
        var totalAmmo = gunComponent.totalAmmo;
        ammoText.SetText(currentAmmo + " / " + totalAmmo);

    }
}
