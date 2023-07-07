using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {
    public bool isTriggered;

    private ActivatableDoor activatableDoor;

    // Use this for initialization
    void Start ()
    {
        isTriggered = false;
    }

    public void SetActivatableDoor(ActivatableDoor _activatableDoor)
    {
        activatableDoor = _activatableDoor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            isTriggered = true;
            gameObject.SetActive(false);
        }
    }
}
