using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ActivatableDoor : MonoBehaviour {
    [Tooltip("Amount of Score to remove door")]
    public int amountOfScore;

    [Tooltip("To remove door by a doorTrigger")]
    public DoorTrigger doorTrigger;

    [Header("Game Audio Clips")]
    public AudioClip doorSound;
    
    private AudioSource audioSource;
    private MeshRenderer meshRenderer;

    // Use this for initialization
    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (meshRenderer.enabled) {
            // Check if this door has a DoorTrigger object //
            if (doorTrigger != null)
            {
                // check is triggered and enough score //
                if (doorTrigger.isTriggered && GameManager.Instance.GetScore() >= amountOfScore)
                {
                    StartCoroutine(RemoveDoor(2));
                }
            }
            else
            {
                // Only score based //
                if (GameManager.Instance.GetScore() >= amountOfScore)
                {
                    StartCoroutine(RemoveDoor(2));
                }
            }
        }
    }

    IEnumerator RemoveDoor(float _timeBeforeRemoval)
    {
        audioSource.PlayOneShot(doorSound);
        meshRenderer.enabled = false;
        GetComponent<Collider>().enabled = false;
        GetComponent<UnityEngine.AI.NavMeshObstacle>().enabled = false;

        yield return new WaitForSeconds(_timeBeforeRemoval);
        gameObject.SetActive(false);
    }
}
