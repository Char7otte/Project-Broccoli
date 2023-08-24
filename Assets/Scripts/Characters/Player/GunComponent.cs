using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunComponent : MonoBehaviour
{
    [Header("Stats")]
    public float damage = 1.0f;
    public int totalAmmo;
    public int maxMagazineSize = 30;
    [HideInInspector]public int remainingBulletsInMagazine;
    [SerializeField]private float timeBetweenShots = 0.1f; //Fire rate
    [SerializeField]private float reloadTime = default;

    [Header("States")]
    public bool pickedUp = true;
    private bool shooting = false;
    private bool readyToShoot = true;
    private bool reloading = false;

    [Header("Shooting")]
    [SerializeField]private Transform raycastPosition = default;
    [SerializeField]private GameObject muzzleFlash = default;
    private LayerMask enemyLayer;

    // [Header("ShootingAnimations")]
    // private Animator animator;

    private AudioManagerComponent audioManagerComponent;
    

    private void Start() {   
        // animator = GetComponent<Animator>();
        audioManagerComponent = GetComponent<AudioManagerComponent>();
        enemyLayer = LayerMask.GetMask("Enemy");

        remainingBulletsInMagazine = maxMagazineSize;
    }

    private void Update() {
        if (GameManager.Instance.playerHasDied) return;
        if (!GameManager.Instance.playerCanShoot) return;
        MouseInput();
    }

    private void MouseInput() {
        shooting = Input.GetMouseButton(0);
        // animator.SetBool("is_shooting", shooting);

        if (Input.GetKeyDown(KeyCode.R) && !reloading && totalAmmo > 0 && remainingBulletsInMagazine < maxMagazineSize) 
            StartCoroutine(Reload());
        
        if (readyToShoot && shooting && !reloading && remainingBulletsInMagazine > 0) {
            //if (GameManager.Instance.isPaused) return;
            Shoot();
        }
    }

    private void Shoot() {
        var ray = new Ray(raycastPosition.position, raycastPosition.forward);
        if (Physics.Raycast(ray, out var hit, Mathf.Infinity, enemyLayer))
        {
            hit.collider.gameObject.GetComponent<HealthComponent>().DealDamage(damage);
        }

        StartCoroutine(PlayMuzzleFlash(0.05f));
        // animator.SetBool("is_shooting", true);
        
        readyToShoot = false;
        audioManagerComponent.Play("shoot");
        remainingBulletsInMagazine--;
        Invoke("ResetShot", timeBetweenShots);
    }

    private void ResetShot() {
        readyToShoot = true;
    }

    private IEnumerator Reload() {
        reloading = true;
        audioManagerComponent.Play("reload");
        // animator.SetBool("is_shooting", false);
        // animator.SetBool("is_empty", true);
        // animator.SetTrigger("reload");
        yield return new WaitForSeconds(reloadTime);

        reloading = false;
        //animator.SetBool("is_empty", false);
        var bulletsNeedReloaded = maxMagazineSize - remainingBulletsInMagazine;
        
        if (totalAmmo >= bulletsNeedReloaded) {
            totalAmmo -= bulletsNeedReloaded;
            remainingBulletsInMagazine += bulletsNeedReloaded;
        }
        else {
            remainingBulletsInMagazine += totalAmmo;
            totalAmmo = 0;
        }
    }

    private IEnumerator PlayMuzzleFlash(float duration) {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(duration);
        muzzleFlash.SetActive(false);
    }

    public void addAmmo(int amount) {
        totalAmmo += amount;
    }
}
