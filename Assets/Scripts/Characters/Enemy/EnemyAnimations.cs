using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    // private Animator animator;

    // private void Start() {
    //     animator =GetComponent<Animator>();
    // }

    // private void OnCollisionEnter(Collision collision) {
    //     if (collision.gameObject.tag == "Player") {
    //         animator.SetTrigger("Attack");
    //     }
    // }

    private EnemyController enemyController;
    private Animator animator;

    private bool attacking = false;

    void Start() {
        enemyController = GetComponent<EnemyController>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        enemyController.enabled = !attacking;
    }

    private void OnCollisionStay(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            PlayAttackAnimation();
        }
    }

    private void PlayAttackAnimation() {
        if (!attacking) {
            attacking = true;
            animator.SetTrigger("Attack");
            Invoke("AttackingHasFinished", animator.GetCurrentAnimatorStateInfo(0).length);
        }
    }

    private void AttackingHasFinished() {
        attacking = false;
    }
    
}
