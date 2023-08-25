using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    private Animator animator;

    private void Start() {
        animator =GetComponent<Animator>();
    }
}
