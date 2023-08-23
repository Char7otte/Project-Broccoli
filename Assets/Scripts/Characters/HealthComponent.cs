using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    private void Start() {
        currentHealth = maxHealth;
    }

    private void Update() {
        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
    }

    public void DealDamage(float damageAmount) {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Max(currentHealth, 0.0f);
    }

    public void Heal(float healAmount) {
        currentHealth += healAmount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }
}
