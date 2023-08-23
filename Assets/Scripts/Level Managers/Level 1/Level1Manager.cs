using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    public bool hasPlayerApproachedChurch = false;
    public bool hasPlayerPickedUpKey = false;
    private bool playerHealthDecreaseTriggered = false;

    [Header("Dialogue")]
    [SerializeField]private string[] startOfLevel1 = new string[] 
    { 
        "Ow... My head hurts...", 
        "Where am I?", 
        "That bell in the distance... I should check it out."
    };
    [SerializeField]private string[] approachSupplies = new string[] 
    { 
        "Supplies?", 
        "Don't mind if I do..."
    };
    [SerializeField]private string[] approachChurchFirst = new string[] 
    { 
        "It's locked.", 
        "Darn. I guess I should look around.", 
        "Maybe I could find a key or something."
    };
    [SerializeField]private string[] foundKey = new string[] 
    { 
        "Well, I'll be damned.", 
        "A key... I should try it on the church's door.", 
        "Though... Maybe I should look around for more supplies first."
    };
    [SerializeField]private string[] churchDoorUnlock = new string[] 
    { 
        "......?!", 
        "What was that?!"
    };

    private void Start() {
        StartCoroutine(PlayerDialogueManager.Instance.RunDialogue(startOfLevel1));
    }

    private void Update() {
        if (!playerHealthDecreaseTriggered) {
            playerHealthDecreaseTriggered = true;
            var player = GameObject.FindGameObjectWithTag("Player");
            var playerHealthComponent = player.GetComponent<HealthComponent>();
            playerHealthComponent.currentHealth = playerHealthComponent.maxHealth / 10;
        }

        if (GameManager.Instance.keysFound > 0 && !hasPlayerPickedUpKey) {
            hasPlayerPickedUpKey = true;
            StartCoroutine(PlayerDialogueManager.Instance.RunDialogue(foundKey));
        }
    }

    public void SuppliesApproach() {
        StartCoroutine(PlayerDialogueManager.Instance.RunDialogue(approachSupplies));
    }
}
