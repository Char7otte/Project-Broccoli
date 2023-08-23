using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjectOnTrigger : MonoBehaviour
{
    [SerializeField]private GameObject objectToDisplay = default;
    
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            objectToDisplay.SetActive(true);
            Destroy(objectToDisplay, 10);
        }
    }
}
