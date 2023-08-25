using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOSenemyAnimations : MonoBehaviour
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

    private LOSenemyController LOSenemycontroller;
    private Animator animator;

    private bool attacking = false;

    void Start() {
        LOSenemycontroller = GetComponent<LOSenemyController>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        LOSenemycontroller.enabled = !attacking;
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
