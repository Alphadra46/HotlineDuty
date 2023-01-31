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
        
        GameObject bullet = Instantiate(bulletPrefab, weaponTip.position,weaponTip.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(weaponTip.right * shootForce,ForceMode.Impulse);
        actualAmmo--;
        lastTimeShoot = Time.time;
        Destroy(bullet,bulletLifeTime);

    }
}
