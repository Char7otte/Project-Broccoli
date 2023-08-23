using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDialogueManager : MonoBehaviour
{
    public static PlayerDialogueManager Instance;

    [SerializeField]private TextMeshProUGUI dialogueText = default;
    [SerializeField]private int textDisplayTime = default;
    public Level1Manager level1Manager = default;
    public Level2Manager level2Manager = default;
    [SerializeField]private TextMeshProUGUI objectiveText = default;

    private void Awake() {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }

    private void Start() {
        //StartCoroutine(StartOfLevel1());
    }

    private void StartDialogueCoroutine(string[] dialogue, string objective) {
        StartCoroutine(RunDialogue(dialogue, objective));
    }

    private IEnumerator RunDialogue(string[] dialogue, string objective) {
        foreach (string dialogueItem in dialogue) {
            dialogueText.SetText(dialogueItem);
            yield return new WaitForSeconds(textDisplayTime);
        }
        dialogueText.SetText("");
        if (!string.IsNullOrEmpty(objective)) objectiveText.SetText(objective);
    }

    public void StartOfLevel1() {
        var dialogue = new string[] { "Ow... My head hurts...", "Where am I?", " That bell in the distance... I should check it out."};
        var objective = "Head towards the church.";
        StartDialogueCoroutine(dialogue, objective);
    }

    public void ApproachSupplies() {
        var dialogue = new string[] { "Supplies?", "Don't mind if I do...",};
        StartDialogueCoroutine(dialogue, "");
    }

    public void ApproachChurch() {
        if (!level1Manager.hasPlayerApproachedChurch && !level1Manager.hasPlayerPickedUpKey) {
            level1Manager.hasPlayerApproachedChurch = true;
            var dialogue = new string[] { "Locked...", "I'll have to find a key."};
            var objective = "Find a key to unlock the church door.";
            StartDialogueCoroutine(dialogue, objective);
        }
        else if (level1Manager.hasPlayerPickedUpKey) {
            level1Manager.ChurchUnlocked();
            var dialogue = new string[] { "......?!", "What was that?!"};
            var objective = "Survive.";
            StartDialogueCoroutine(dialogue, objective);
        }
    }

    public void KeyFound() {
        if (!level1Manager.hasPlayerApproachedChurch) {
            var dialogue = new string[] { "A key? I wonder what this is for..."};
            StartDialogueCoroutine(dialogue, "");
        }
        else {
            level1Manager.hasPlayerPickedUpKey = true;
            var dialogue = new string[] { "There we go.", "But maybe I should look around for more supplies first... "};
            var objective = "Unlock the church with the key you found.";
            StartDialogueCoroutine(dialogue, objective);
        }
    }
}
