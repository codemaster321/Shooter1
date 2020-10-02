using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    bool flag = true;
  
    [SerializeField] AmmoType ammoType;
    [SerializeField]Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] GameObject HitEffect;
    Animator anim;


    bool canShoot = true;
    public float timeBetweenShots = 2f;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    //Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0) && canShoot == true && flag==true)
        {
            StartCoroutine(Shoot());
        }

    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetAmmoAmount(ammoType) > 0 && flag==true)
        {
           
            PlayMuzzleFlash();
            anim.SetTrigger("Fire");
            ProcessRaycast();
            ammoSlot.ReduceAmmoAmount(ammoType);

        }
        else 
        {
            StartCoroutine(Reload());
        }

        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;

        

    }

    IEnumerator Reload()
    {
        Debug.Log("reload");
        anim.SetBool("reload",true);
        flag = false;
        yield return new WaitForSeconds(2.5f);
        anim.SetBool("reload",false);
        Debug.Log("reload false");
        ammoSlot.IncreaseAmmoAmount(ammoType,10);
        flag = true;
        
        
    }

    private void PlayMuzzleFlash()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range) && hit.transform.gameObject.tag=="Building")
        {
            CreateHitEffect(hit);
            
        }
    }

    private void CreateHitEffect(RaycastHit hit)
    {
        GameObject ob = Instantiate(HitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {

            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);

        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject ob = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(ob, 0.1f);
    }
}
