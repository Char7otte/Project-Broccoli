using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKey : MonoBehaviour
{
    //[SerializeField]private GameObject[] keySpawnLocations = default;
    [SerializeField]private GameObject keyPrefab = default;
    [SerializeField]

    private void Start() {
        GameObject[] keySpawnLocations = GameObject.FindGameObjectsWithTag("Key Spawn Location");

        int randomInt = Random.Range(0, keySpawnLocations.Length);
        SelectKeySpawnLocation(randomInt, keySpawnLocations);
    }

    private void SelectKeySpawnLocation(int randomInt, GameObject[] spawnLocations) {
        var number = 0;

        foreach (var spawnLocation in spawnLocations) {
            if (number == randomInt) {
                // var randomRotation = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
                // var parent = GameObject.Find("===PICKUPS===").transform;
                // Instantiate(keyPrefab, spawnLocation.transform.position, Quaternion.Euler(randomRotation), parent);

                var itemSpawnerComponent = GetComponent<SpawnItemScript>();
                itemSpawnerComponent.SpawnItem(keyPrefab, spawnLocation.transform);
                return;
            }
            number++;
        }
    }
}
