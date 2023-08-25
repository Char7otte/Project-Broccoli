using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField]private GameObject bossEnemy = default;
    [SerializeField]private Image healthbarImage = default;

    private HealthComponent bossHealthComponent = default;

    private void Start() {
        bossHealthComponent = bossEnemy.GetComponent<HealthComponent>();
    }

    private void Update() {
        healthbarImage.fillAmount = bossHealthComponent.currentHealth / bossHealthComponent.maxHealth;
    }
}
