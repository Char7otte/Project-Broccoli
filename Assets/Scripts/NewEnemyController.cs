using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyController : MonoBehaviour
{   
    public GameObject player;

    public float movementSpeed;

    private void Start() {
        player = GameObject.Find("Player");
    }

    private void Update() {
        transform.LookAt(player.transform.position);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }
}
