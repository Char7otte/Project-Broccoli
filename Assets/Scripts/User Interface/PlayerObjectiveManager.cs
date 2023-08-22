using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerObjectiveManager : MonoBehaviour
{
    public static PlayerObjectiveManager Instance;

    [SerializeField]private TextMeshProUGUI objectiveText = default;

    private void Awake() {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }

    public void ChangeObjectiveText(string objectiveTextString) {
        objectiveText.SetText(objectiveTextString);
    }
}
