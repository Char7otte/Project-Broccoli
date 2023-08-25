using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BossEnemyControll : MonoBehaviour
{
    [SerializeField]private float movementSpeed = default;

    private Transform player;
    private NavMeshAgent navMeshAgent;


    private void Start () {
        player = GameObject.Find("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = movementSpeed;
    }

    private void Update() {
        transform.LookAt(player);
    }

    private void FixedUpdate() {
        navMeshAgent.SetDestination(player.position);
    }
}
