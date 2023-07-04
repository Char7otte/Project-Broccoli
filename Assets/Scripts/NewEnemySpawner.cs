using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    
    public float time_to_spawn_enemy;
    private float timer;

    private void Update()
    {
        if (NewGameManager.instance.maximum_enemy_count > 0) SpawnEnemyTimer();
    }

    private void SpawnEnemyTimer()
    {
        timer += Time.deltaTime;
        if (timer >= time_to_spawn_enemy) SpawnEnemy();
    }

    private void SpawnEnemy() 
    {
        Instantiate(EnemyPrefab, transform.position, Quaternion.identity, gameObject.transform);
        timer = 0;

        NewGameManager.instance.maximum_enemy_count--;
        print(NewGameManager.instance.maximum_enemy_count);
    }
}
