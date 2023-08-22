using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemScript : MonoBehaviour
{
    public void SpawnItem(GameObject itemPrefab, Transform spawnPosition) {
        var randomRotation = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        var parent = GameObject.Find("===PICKUPS===").transform;
        Instantiate(itemPrefab, spawnPosition.position, Quaternion.Euler(randomRotation), parent);
    } 
}
