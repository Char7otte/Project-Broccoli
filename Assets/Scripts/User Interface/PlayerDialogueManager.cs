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

    private void Awake() {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }

    public IEnumerator RunDialogue(string[] dialogueTextStringArray) {
        foreach (string dialogue in dialogueTextStringArray) {
            dialogueText.SetText(dialogue);
            yield return new WaitForSeconds(textDisplayTime);
        }
        dialogueText.SetText("");
    }
}
