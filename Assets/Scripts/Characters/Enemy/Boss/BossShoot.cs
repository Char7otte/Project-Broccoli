using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    [SerializeField]private float timeToShoot = default;
    [SerializeField]private GameObject projectilePrefab = default;
    [SerializeField]private Transform projectileSpawnLocation = default;
    private float shootTimer;

    private void Update() {
        shootTimer += Time.deltaTime;
        if (shootTimer >= timeToShoot) {
            Shoot();
        }
    }

    private void Shoot() {
        //var playerPosition = GameObject.Find("Player").transform.position;
        Instantiate(projectilePrefab, projectileSpawnLocation.position, Quaternion.identity);
        shootTimer = 0;
    }
}
