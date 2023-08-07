using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunApproachTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            PlayerDialogueManager.Instance.GunApproach();
            Destroy(gameObject);
        }
    }
}
