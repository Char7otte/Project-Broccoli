using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Tooltip("Shooting rate of the player")]
    public float ShootingRate;

    [Tooltip("Damage on enemy on each hit")]
    public int ShootingDamage;

    [Tooltip("Damage speed with contact with enemy")]
    public int DamageRate;

    // [Tooltip("Starting health of the enemy")]
    // public int HealthPoint;

    [Tooltip("Starting ammo of the enemy")]
    public int ammoCount;

    //[Tooltip("Shooting sound effect")]
    //public AudioClip ShootingAudioClip;

    // Reference to muzzle flash //
    public GameObject MuzzleFlash;

    private Rigidbody rb = null;
    private Vector3 moveDirection = Vector3.zero;
    private bool canShoot;
    private bool canDamage;
    //private AudioSource audioSource;
    private AudioManagerComponent audioManagerComponent;
    private GameObject camera = null;
    

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //audioSource = GetComponent<AudioSource>();
        audioManagerComponent = GetComponent<AudioManagerComponent>();

        canShoot = true;
        canDamage = true;
        //audioSource.clip = ShootingAudioClip;
        camera = GameObject.FindGameObjectWithTag("MainCamera");

        GameManager.Instance.UpdateAmmo(ammoCount);
        //GameManager.Instance.UpdateHealth(HealthPoint);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameOver)
            return;

        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetMouseButton(0) && canShoot && ammoCount > 0)
        {
            // Play muzzle flash //
            StartCoroutine(PlayMuzzleFlash(0.05f));

            StartCoroutine(SpawnBullet());
        }
    }

    // Play muzzle flash function //
    private IEnumerator PlayMuzzleFlash(float duration)
    {
        MuzzleFlash.SetActive(true);
        yield return new WaitForSeconds(duration);
        MuzzleFlash.SetActive(false);
    }

    private IEnumerator SpawnBullet()
    {
        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position + camera.transform.forward, camera.transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.tag.Equals("Enemy"))
            {
                //hit.collider.gameObject.GetComponent<EnemyScript>().OnHit(ShootingDamage);
            }
        }

        //audioSource.PlayOneShot(ShootingAudioClip);
        audioManagerComponent.Play("shoot");

        GameManager.Instance.UpdateAmmo(--ammoCount);

        canShoot = false;
        //wait for some time
        yield return new WaitForSeconds(ShootingRate);

        canShoot = true;
    }

    // private void OnTriggerStay(Collider collision)
    // {
    //     if (collision.gameObject.tag.Equals("Enemy") && canDamage)
    //     {
    //         StartCoroutine(GetDamage(collision));
    //     }
    // }

    // private IEnumerator GetDamage(Collider collision)
    // {
    //     EnemyScript enemyScript = collision.gameObject.GetComponent<EnemyScript>();
    //     HealthPoint -= enemyScript.ContactDamage;
    //     GameManager.Instance.UpdateHealth(HealthPoint);

    //     if (HealthPoint <= 0)
    //     {
    //         Dead();
    //     }

    //     canDamage = false;
    //     //wait for some time
    //     yield return new WaitForSeconds(DamageRate);

    //     canDamage = true;
    // }

    private void Dead()
    {
        Destroy(gameObject);
    }

    public void AddAmmo(int ammo, AudioClip audioClip)
    {
        ammoCount += ammo;
        GameManager.Instance.UpdateAmmo(ammoCount);

        //audioSource.PlayOneShot(audioClip);
        AudioManagerMaster.Instance.Play("Ammo Pickup");
    }

    // public void AddHealth(int health, AudioClip audioClip)
    // {
    //     HealthPoint += health;
    //     GameManager.Instance.UpdateHealth(HealthPoint);

    //     //audioSource.PlayOneShot(audioClip);
    //     AudioManagerMaster.Instance.Play("Health Pickup");
    // }
}
