using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDialogueManager : MonoBehaviour
{
    public static PlayerDialogueManager Instance;

    [SerializeField]private TextMeshProUGUI dialogueText = default;
    [SerializeField]private int textDisplayTime = default;

    private void Awake() {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }

    private void Start() {
        StartCoroutine(StartOfLevel1());
    }

    private void SetTimeScale(float timeScaleValue) {
        Time.timeScale = timeScaleValue;
    }

    private void ChangeDialogueText(string dialougeTextString) {
        dialogueText.SetText(dialougeTextString);
    }

    private IEnumerator StartOfLevel1() {
        ChangeDialogueText("Ow... My head hurts...");
        yield return new WaitForSeconds(textDisplayTime);
        ChangeDialogueText("Where am I? What happened?");
        yield return new WaitForSeconds(textDisplayTime);
        ChangeDialogueText("That bell in the distance... I should check it out.");
        yield return new WaitForSeconds(textDisplayTime);
        ChangeDialogueText("");
    }

    public void GunApproach() {
        StartCoroutine(_GunApproach());
    }

    private IEnumerator _GunApproach() {
        ChangeDialogueText("Supplies?");
        yield return new WaitForSeconds(textDisplayTime);
        ChangeDialogueText("Don't mind if I do...");
        yield return new WaitForSeconds(textDisplayTime);
        ChangeDialogueText("");
    }

    public void ChurchDoorFirstApproach() {
        StartCoroutine(_ChurchDoorFirstApproach());
    }

    private IEnumerator _ChurchDoorFirstApproach() {
        ChangeDialogueText("Locked...");
        yield return new WaitForSeconds(textDisplayTime);
        ChangeDialogueText("I'll have to find a key.");
        yield return new WaitForSeconds(textDisplayTime);
        ChangeDialogueText("");
        PlayerObjectiveManager.Instance.ChangeObjectiveText("Find a key to unlock the church door.");
    }

    public void KeyFound() {
        StartCoroutine(_KeyFound());
    }

    private IEnumerator _KeyFound() {
        ChangeDialogueText("There we go...");
        yield return new WaitForSeconds(textDisplayTime);
        ChangeDialogueText("Should I explore some more? There might be more resources around.");
        yield return new WaitForSeconds(textDisplayTime);
        ChangeDialogueText("");
        PlayerObjectiveManager.Instance.ChangeObjectiveText("Unlock the church with the key you found.");
    }

    public void ChurchDoorUnlocked() {
        StartCoroutine(_ChurchDoorUnlocked());
    }

    private IEnumerator _ChurchDoorUnlocked() {
        AudioManagerMaster.Instance.Play("enemy alert");
        ChangeDialogueText("...?!");
        yield return new WaitForSeconds(textDisplayTime);
        ChangeDialogueText("Oh no... What was that...?");
        yield return new WaitForSeconds(textDisplayTime);
        ChangeDialogueText("");
        PlayerObjectiveManager.Instance.ChangeObjectiveText("Survive.");
    }
}
