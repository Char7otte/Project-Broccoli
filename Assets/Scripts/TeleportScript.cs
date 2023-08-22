using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    [SerializeField]private Transform teleportLocation = default;
    private GameObject currentRoom;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            if (currentRoom != null) {
                currentRoom.SetActive(false);
            }

            currentRoom = teleportLocation.parent.gameObject;
            currentRoom.SetActive(true);

            var characterController = other.GetComponent<CharacterController>();
            characterController.enabled = false;
            other.transform.position = teleportLocation.position;
            characterController.enabled = true;
        }
    }
}
