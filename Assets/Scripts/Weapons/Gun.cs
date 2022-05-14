using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] CharacterC player;
    public AudioSource bulletSound;
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;
    public int damageAmount = 20;
    public int ammoMax = 30;
    public int currentAmmo;
    public bool currentlyReloading;
    public bool currentlyInspecting;
    public float reloadTime = 2f;
    public float InspectTime = 2f;

    [SerializeField] Animator anim;


    public Camera fpscamera;
    public ParticleSystem muzzleflash;
    public GameObject impactEffect;
    public AudioSource reload;
    public AudioSource gunEmpty;

    private float nextTimeToFire = 0f;

    private void Start()
    {
        currentAmmo = ammoMax;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        limit();

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && PauseMenu.GameIsPaused == false)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            StartCoroutine("InspectGun");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if(currentAmmo < ammoMax)
            {
                StartCoroutine("ReloadGun");
            }
        }

    }

    void limit()
    {
        if (currentAmmo <= 0)
            currentAmmo = 0;
        if (currentAmmo >= ammoMax)
            currentAmmo = ammoMax;
    }

    void Shoot()
    {
        if (!currentlyInspecting)
        {
            if (!player.isSprinting)
            {

                if (!currentlyReloading)
                {
                    if (currentAmmo == 0)
                    {
                        gunEmpty.Play();
                    }

                    else if (currentAmmo >= 1)
                    {
                        muzzleflash.Play();
                        bulletSound.Play();
                        currentAmmo--;
                        RaycastHit hit;
                        if (Physics.Raycast(fpscamera.transform.position, fpscamera.transform.forward, out hit, range))
                        {
                            // UnityEngine.Debug.Log(hit.transform.name);

                            Target target = hit.transform.GetComponent<Target>();
                            if (target != null)
                            {
                                target.TakeDamage(damage);
                            }

                            if (hit.rigidbody != null)
                            {
                                hit.rigidbody.AddForce(-hit.normal * impactForce);
                            }

                            EnemyDamage e = hit.transform.GetComponent<EnemyDamage>();
                            if (e != null)
                            {
                                e.TakeDamage(damageAmount);
                                return;
                            }

                            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                            Destroy(impactGO, 2f);
                        }

                    }
                }
            }
            
        }

    }

    IEnumerator ReloadGun()
    {
        currentlyReloading = true;

        anim.SetTrigger("ReloadActive");
        reload.Play();
        yield return new WaitForSeconds(reloadTime);

        for (int i = 0; i < ammoMax; i++)
        {
            currentAmmo++;
        }

        currentlyReloading = false;
    }

    IEnumerator InspectGun()
    {
        currentlyInspecting = true;
    
        anim.SetTrigger("InspectActive");
        yield return new WaitForSeconds(InspectTime);

        currentlyInspecting = false;
    }
}
