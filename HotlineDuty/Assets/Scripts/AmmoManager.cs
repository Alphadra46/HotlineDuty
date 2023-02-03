using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public int maxAmmo;
    public int actualAmmo;
    public float rateOfFire;
    public bool isAutomatic;
    public int damagePerBullet;
    public int bulletLifeTime;
    public GameObject bulletPrefab;
    public float shootForce;

    private float lastTimeShoot;
    private Transform weaponTip;
    private Shoot shootScript;
    
    [SerializeField] AudioSource reloadSound;
    [SerializeField] AudioSource shootSound;

    private void Start()
    {
        shootScript = FindObjectOfType<Shoot>();
        weaponTip = GameObject.Find("WeaponTip").transform;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && isAutomatic && shootScript.isAWeaponEquipped)
        {
            Shoot();
        }

        if (Input.GetKey(KeyCode.R))
        {
            
            Reload();
        }
        
        
    }

    public void Shoot()
    {
        if (actualAmmo == 0)
            return;
        
        if (isAutomatic)
        {
            if (Time.time <= lastTimeShoot + rateOfFire)
                return;
        }
        
        CameraShake.instance.ShakeCamera(0.1f,3f);
        GameObject bullet = Instantiate(bulletPrefab, weaponTip.position,shootScript.transform.rotation);
        bullet.transform.Rotate(0,0,-90);
        bullet.GetComponent<Rigidbody2D>().AddForce(weaponTip.right * shootForce, ForceMode2D.Impulse);
        shootSound.Play();
        actualAmmo--;
        lastTimeShoot = Time.time;
        Destroy(bullet,bulletLifeTime);

    }
    
    public void Reload()
    {
        if (maxAmmo >= 15 && actualAmmo != 15)
        {
            reloadSound.Play();
            var ammoToReload = 15 - actualAmmo;
            actualAmmo += ammoToReload;
            maxAmmo -= ammoToReload;
        }
        else
            return;
    }
    
    public void AddAmmo(int ammoToAdd)
    {
        maxAmmo += ammoToAdd;
    }
}
