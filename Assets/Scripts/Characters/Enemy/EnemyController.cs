using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour 
{
    [SerializeField]private float movementSpeed = default;

    private Transform player;
    private NavMeshAgent navMeshAgent;

    private void Start () {
        player = GameObject.Find("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = movementSpeed;
    }
	
	private void FixedUpdate () {
        if (player == null) return;

        navMeshAgent.SetDestination(player.position);
    }
}
