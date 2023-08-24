using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDoor : MonoBehaviour
{
    [SerializeField]private GameObject door;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            door.SetActive(true);
        }
    }
}
