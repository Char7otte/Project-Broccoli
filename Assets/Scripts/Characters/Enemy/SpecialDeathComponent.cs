﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialDeathComponent : MonoBehaviour
{
    public bool isAlive = true;

    [SerializeField]private Behaviour[] componentsToDisable = default;
    [SerializeField]private bool immediatelyDestroyObject = true;
    [SerializeField]private Level2Manager level2Manager;

    private HealthComponent healthComponent;
    private AudioManagerComponent audioManagerComponent;
    //private Animator animator;

    private void Start() {
        level2Manager.enemyCountInRoom3 += 1;
        healthComponent = GetComponent<HealthComponent>();
        audioManagerComponent = GetComponent<AudioManagerComponent>();
        //animator = GetComponent<Animator>();
    }

    private void Update() {
        if (healthComponent.currentHealth <= 0 && isAlive == true) {
            Died();
        }
    }

    private void Died() {
        isAlive = false;
        
        //animator.SetTrigger("dead");
        //Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length * 2);

        if (immediatelyDestroyObject) {
            level2Manager.enemyCountInRoom3 -= 1;
            Destroy(gameObject);
        }
        PlayAudio("died");
        DisableTheseComponentsUponDeath();
    }

    private void DisableTheseComponentsUponDeath() {
        GetComponent<Collider>().enabled = false; //Stuff like this is why I prefer Godot. Colliders don't inherit from Behaviour for some reason.

        foreach(Behaviour behaviour in componentsToDisable) {
            behaviour.enabled = false;
        }
    }

    private void PlayAudio(string clipName) {
        if (audioManagerComponent == null) return;
        
        audioManagerComponent.Play(clipName);
    }
}
