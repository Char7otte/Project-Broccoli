using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField]private float speed = default;

    private void Start() {
        Destroy(this.gameObject, 5);
        var player = GameObject.Find("Player").transform;
        transform.LookAt(player);
    }

    private void Update() {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
