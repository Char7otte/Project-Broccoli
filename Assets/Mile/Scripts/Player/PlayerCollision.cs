using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour 
{  
    [Header("InvincibilityFrames")]
    [SerializeField]private float invincibilityFramesDuration = 1.0f;
    private float invincibilityFramesTimer;

    private void Update() {
        invincibilityFramesTimer = invincibilityFramesTimer - Time.deltaTime;
        invincibilityFramesTimer = Mathf.Max(invincibilityFramesTimer, 0.0f);
    }

    private void OnCollisionStay(Collision collision) {
        if (collision.gameObject.tag == "Enemy" && invincibilityFramesTimer <= 0) {
            var damageComponent = collision.gameObject.GetComponent<DamageComponent>();
            EnemyCollision(damageComponent);
        }
    }

    private void EnemyCollision(DamageComponent enemyDamageComponent) {
        invincibilityFramesTimer = invincibilityFramesDuration;

        var enemyDamage = enemyDamageComponent.damage;
        var healthComponent = GetComponent<HealthComponent>();
        healthComponent.DealDamage(enemyDamage);
    }
}
