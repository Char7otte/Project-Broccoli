using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDoor : MonoBehaviour
{
    [SerializeField]private GameObject door = default;
    [SerializeField]private Level2Manager level2Manager = default;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            door.SetActive(true);
            level2Manager.StartBossFight();
            PlayerDialogueManager.Instance.BossFight();
        }
    }
}
