using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaFireControl : MonoBehaviour
{
    [SerializeField]private GameObject fire;

    private void Start() {
        Invoke("EnableDamagingFire", 3);
    }

    private void EnableDamagingFire() {
        fire.SetActive(true);
    }
}
