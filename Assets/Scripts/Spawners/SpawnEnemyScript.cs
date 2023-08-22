using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyScript : MonoBehaviour
{
    [SerializeField]private GameObject enemyPrefab = default;

    public void SpawnEnemy() {
        GetComponent<SpawnItemScript>().SpawnItem(enemyPrefab, transform);
    }
}
