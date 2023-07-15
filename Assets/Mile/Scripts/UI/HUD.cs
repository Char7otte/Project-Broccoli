using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]private GameObject player;

    [SerializeField]private Image healthbarImage;
    [SerializeField]private TextMeshProUGUI ammoText;

    [SerializeField]private TextMeshProUGUI healthText;
    [SerializeField]private TextMeshProUGUI scoreText;



    private void Update() {
        var healthComponent = player.GetComponent<HealthComponent>();
        var currentHealth = healthComponent.currentHealth;
        var maxHealth = healthComponent.maxHealth;
        healthbarImage.fillAmount = currentHealth / maxHealth;
        healthText.SetText("Health: " + currentHealth);

        // var gunComponent = GunSelector.currentWeapon.GetComponent<GunComponent>();
        // var currentAmmo = gunComponent.remainingBulletsInMagazine;
        // var maxMagazineSize = gunComponent.maxMagazineSize;
        // ammoText.SetText(currentAmmo + " / " + maxMagazineSize);

        // var score = 
        // scoreText.SetText("Score: " + score);
    }
}
