using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour {
    [Tooltip("Amount of health to be given to player")]
    public int HealthToRegen;

    [Tooltip("Sound upon picking up")]
    public AudioClip PickUpAudioClip;

    private float AnimateSpeed = 100;
    private PickUpSpawner pickUpSpawner;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(Vector3.up, AnimateSpeed * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.Equals("Player")) {
            collider.gameObject.GetComponent<PlayerScript>().AddHealth(HealthToRegen, PickUpAudioClip);

            Destroy(gameObject);
        }
    }
}
