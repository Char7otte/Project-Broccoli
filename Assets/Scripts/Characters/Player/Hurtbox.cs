using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour 
{  
    [Header("EnemyInvincibilityFrames")]
    [SerializeField]private float enemyInvincibilityFramesDuration = 1.0f;
    private float enemyInvincibilityFramesTimer;

    // [Header("FireInvincibilityFrames")]
    // [SerializeField]private float fireInvincibilityFramesDuration = 0.1f;
    // [SerializeField]private float fireDamage = 1;
    // private float fireInvincibilityFramesTimer;

    private HealthComponent healthComponent;

    private void Start() {
        healthComponent = GetComponent<HealthComponent>();
    }

    private void Update() {
        enemyInvincibilityFramesTimer -= Time.deltaTime;
        enemyInvincibilityFramesTimer = Mathf.Max(enemyInvincibilityFramesTimer, 0.0f);

        // fireInvincibilityFramesTimer -=Time.deltaTime;
        // fireInvincibilityFramesTimer = Mathf.Max(fireInvincibilityFramesTimer, 0.0f);
    }

    private void OnCollisionStay(Collision collision) {
        if (collision.gameObject.tag == "Enemy" && enemyInvincibilityFramesTimer <= 0) {
            var damageValue = collision.gameObject.GetComponent<DamageValue>();
            EnemyCollision(damageValue);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            var damageValue = other.gameObject.GetComponent<DamageValue>();
            EnemyCollision(damageValue);
        }
    }

    private void EnemyCollision(DamageValue enemyDamageValue) {
        enemyInvincibilityFramesTimer = enemyInvincibilityFramesDuration;

        var enemyDamage = enemyDamageValue.damage;
        healthComponent.DealDamage(enemyDamage);
    }

//     private void OnTriggerStay(Collider other) {
//         if (other.gameObject.tag == "Fire" && fireInvincibilityFramesTimer <= 0) {
//             fireCollision(fireDamage);
//         }
//     }

//     private void fireCollision(float _fireDamage) {
//         fireInvincibilityFramesTimer = fireInvincibilityFramesDuration;
//         healthComponent.DealDamage(_fireDamage);
//     }
}
