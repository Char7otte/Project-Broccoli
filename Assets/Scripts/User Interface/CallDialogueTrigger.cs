using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallDialogueTrigger : MonoBehaviour
{
    [SerializeField]private string[] dialogueArray = default;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            StartCoroutine(PlayerDialogueManager.Instance.RunDialogue(dialogueArray));
        }
    }
}
