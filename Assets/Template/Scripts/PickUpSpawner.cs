using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour {
    [Tooltip("Time the spawner start after starting the scene")]
    public float StartTime;

    [Tooltip("Duration the spawner will spawn continuously")]
    public float SpawnDuration;

    [Tooltip("Time the spawner end spawning")]
    public float SpawnRate;

    [Tooltip("Pickup prefeb to be spawned")]
    public GameObject PickUpPrefeb;

    [Tooltip("Destory spawner after spawning")]
    public bool DestoryAfterSpawning;

    [Tooltip("Sound upon spwaning a pickup")]
    public AudioClip SpawnPickupAudioClip;

    private GameObject SpawnedObject;
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SpawnDuration = (SpawnDuration <= 0) ? float.MaxValue : SpawnDuration;

        InvokeRepeating("StartSpawner", StartTime, SpawnRate);
        StartCoroutine(StopSpawning());
    }

    void StartSpawner()
    {
        if (GameManager.Instance.isGameOver)
        {
            CancelInvoke("StartSpawner");
            return;
        }

        if (SpawnedObject == null)
        {
            SpawnedObject = Instantiate(PickUpPrefeb, transform.position, Quaternion.identity);
            audioSource.PlayOneShot(SpawnPickupAudioClip);
        }
    }

    private IEnumerator StopSpawning()
    {
        yield return new WaitForSeconds(StartTime + SpawnDuration);
        CancelInvoke("StartSpawner");

        if (DestoryAfterSpawning)
        {
            Destroy(gameObject);
        }
    }
}
