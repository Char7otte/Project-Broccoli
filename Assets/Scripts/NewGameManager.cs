using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameManager : MonoBehaviour
{
    public static NewGameManager instance;
    public int maximum_enemy_count;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    
}
