using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySignifier : MonoBehaviour
{
    [SerializeField]private Level2Manager level2Manager;
    private HealthComponent healthComponent;
    private bool triggered = default;

    private void Start() {
        level2Manager.enemyCountInRoom3 += 1;
        healthComponent = GetComponent<HealthComponent>();
    }

    private void Update() {
        if (healthComponent.currentHealth <= 0 && triggered == false) {
            triggered = true;
            level2Manager.enemyCountInRoom3 -= 1;
        }
    }
}
