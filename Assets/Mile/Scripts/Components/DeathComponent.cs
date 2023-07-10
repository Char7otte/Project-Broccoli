using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathComponent : MonoBehaviour
{
    private HealthComponent healthComponent;
    public bool isAlive = true;

    private void Start() {
        healthComponent = GetComponent<HealthComponent>();
    }

    private void Update() {
        if (healthComponent.currentHealth <= 0 && isAlive) {
            print("Player is dead.");
            isAlive = false;
        }
    }
}
