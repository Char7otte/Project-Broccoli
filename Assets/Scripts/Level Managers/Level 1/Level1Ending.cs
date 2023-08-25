using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Ending : MonoBehaviour
{
    private DeathComponent deathComponent;
    [SerializeField]private Level1Manager level1Manager = default;
    [SerializeField]private GameObject level1EndScreen = default;

    private void Start() {
        deathComponent = GetComponent<DeathComponent>();
    }

    private void Update() {
        if (!level1Manager.churchIsUnlocked) return;
        if (deathComponent.isAlive) return;

        level1EndScreen.SetActive(true);
        Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Confined;
        Destroy(this.gameObject);
    }
}
