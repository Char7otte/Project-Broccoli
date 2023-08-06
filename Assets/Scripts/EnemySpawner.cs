using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private GameObject enemyPrefab = default;

    public void SpawnEnemy() {
        var itemSpawnerComponent = GetComponent<ItemSpawnerComponent>();
        itemSpawnerComponent.SpawnItem(enemyPrefab, transform);
    }
}
