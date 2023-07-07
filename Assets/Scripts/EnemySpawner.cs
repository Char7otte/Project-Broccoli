using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [Tooltip("Time the spawner start after starting the scene")]
    public float StartTime;

    [Tooltip("Duration the spawner will spawn continuously")]
    public float SpawnDuration;

    [Tooltip("Time the spawner end spawning")]
    public float SpawnRate;

    [Tooltip("Enemy prefeb to be spawned")]
    public GameObject EnemyPrefeb;

    [Tooltip("Destory spawner after spawning")]
    public bool DestoryAfterSpawning;

    [Tooltip("Sound upon spwaning an enemy")]
    public AudioClip SpawnEnemyAudioClip;

    public EnemySpawnerTrigger EnemySpawnerTrigger;

    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();

        if (EnemySpawnerTrigger == null)
        {
            InitializedSpawner();
        }
        else
        {
            EnemySpawnerTrigger.GetComponent<EnemySpawnerTrigger>().SetEnemySpawner(this);
        }
    }

    private void StartSpawner()
    {
        if (GameManager.Instance.isGameOver)
        {
            CancelInvoke("StartSpawner");
            return;
        }

        Instantiate(EnemyPrefeb, transform.position, Quaternion.identity);
        audioSource.PlayOneShot(SpawnEnemyAudioClip);
    }

    private IEnumerator StopSpawning()
    {
        yield return new WaitForSeconds(StartTime + SpawnDuration);
        CancelInvoke("StartSpawner");

        if (DestoryAfterSpawning) {
            Destroy(gameObject);
        }
    }

    public void InitializedSpawner()
    {
        InvokeRepeating("StartSpawner", StartTime, SpawnRate);
        StartCoroutine(StopSpawning());
    }
}
