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

    private AmmoManager weaponAmmoManager;
    private Transform weaponTip;//The very tip of the weapon, where the bullet will be shoot and instantiate

    private void Start()
    {
        weaponTip = GameObject.Find("WeaponTip").transform;
        InputManager.instance.shoot.started += ShootWithWeaponInput;
    }

    public void ShootWithWeaponInput(InputAction.CallbackContext context)
    {
        ShootWithWeapon();
    }
    
    private void ShootWithWeapon()
    {
        if (!isAWeaponEquipped)
            return;
        
        weaponAmmoManager = GetComponent<PickUpScript>().weaponToInteract.GetComponent<AmmoManager>();

        weaponAmmoManager.Shoot();
    }
}
