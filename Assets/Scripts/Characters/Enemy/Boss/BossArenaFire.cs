using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArenaFire : MonoBehaviour
{
    [SerializeField]private float timeToShoot = default;
    [SerializeField]private GameObject projectilePrefab = default;
    
    private float shootTimer;

    private void Update() {
        shootTimer += Time.deltaTime;
        if (shootTimer >= timeToShoot) {
            SpawnFire();
        }
    }

    private void SpawnFire() {
        var playerPosition = GameObject.Find("Player").transform.position;
        if (playerPosition == null) return;
        
        Instantiate(projectilePrefab, playerPosition, Quaternion.identity);
        shootTimer = 0;
    }
}
