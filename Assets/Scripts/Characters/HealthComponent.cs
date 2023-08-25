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

    public void DealDamage(float damageAmount) {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Max(currentHealth, 0.0f);

        PlayHurt();

        if (GetComponent<Animator>() == null) return;
        GetComponent<Animator>().enabled = true;
    }

    public void Heal(float healAmount) {
        currentHealth += healAmount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }

    private void PlayHurt() {
        var audioComponent = GetComponent<AudioManagerComponent>();
        if (audioComponent == null) return;

        audioComponent.Play("hurt");
    }
}
