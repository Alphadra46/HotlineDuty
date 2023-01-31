using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootForce = 2f;

    [HideInInspector] public bool isAWeaponEquipped = false;

    private Transform weaponTip;//The very tip of the weapon, where the bullet will be shoot and instantiate

    private void Start()
    {
        weaponTip = GameObject.Find("WeaponTip").transform;
        InputManager.instance.shoot.started += ShootWithWeapon;
    }

    public void ShootWithWeapon(InputAction.CallbackContext context)
    {
        if (!isAWeaponEquipped)
            return;
        
        GameObject bullet = Instantiate(bulletPrefab, weaponTip.position,weaponTip.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(weaponTip.right * shootForce,ForceMode.Impulse);
        
        Destroy(bullet,2f);
    }
}
