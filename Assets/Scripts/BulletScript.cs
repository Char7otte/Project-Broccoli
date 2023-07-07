using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [Tooltip("Speed of the bullet")]
    public float MovementSpeed;

    [Tooltip("Sound upon impact")]
    public AudioClip ImpactAudioClip;

    [SerializeField]
    public int BulletDamage;

    private Rigidbody rb;
    private AudioSource audioSource;
    private float timeToLive = 3;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        rb.velocity = transform.forward * MovementSpeed;
        Destroy(gameObject, timeToLive);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Wall"))
        {
            audioSource.PlayOneShot(ImpactAudioClip);
        }

        rb.useGravity = true;
    }
}