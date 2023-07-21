using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour 
{
    [SerializeField]private float movementSpeed = default;

    private Transform player;
    private NavMeshAgent navMeshAgent;
    private bool playerDetected = false;

    private void Start () {
        player = GameObject.Find("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = movementSpeed;
    }

    private void Update() {
        transform.LookAt(player);
    }
	
	private void FixedUpdate () {
        if (player == null) return;
        if (!playerDetected) return;

        navMeshAgent.SetDestination(player.position);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            playerDetected = true;
        }
    }
}
