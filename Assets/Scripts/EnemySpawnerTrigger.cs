using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerTrigger : MonoBehaviour {
    [Tooltip("Set the trigger to trigger only once")]
    public bool TriggerOnce;

    private EnemySpawner enemySpawner;
    private bool triggeredBefore;

    // Use this for initialization
	void Start ()
    {
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (TriggerOnce)
            {
                if (!triggeredBefore)
                {
                    enemySpawner.InitializedSpawner();
                    triggeredBefore = true;
                }
            }
            else
            {
                enemySpawner.InitializedSpawner();
            }
        }
    }

    public void SetEnemySpawner(EnemySpawner _enemySpawner)
    {
        enemySpawner = _enemySpawner;

        // Set spawner start time to 0, to start upon triggered //
        enemySpawner.StartTime = 0;     

        if (!TriggerOnce)
        {
            enemySpawner.DestoryAfterSpawning = false;
        }
    }
}
