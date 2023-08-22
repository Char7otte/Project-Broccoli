using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallDialogueTrigger : MonoBehaviour
{
    [SerializeField]private string methodName = default;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            PlayerDialogueManager.Instance.Invoke(methodName, 0);
        }
    }
}
