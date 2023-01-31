using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpScript : MonoBehaviour
{
    [SerializeField] private Transform weaponSlot;
    private Shoot shootScript;

    [HideInInspector] public GameObject weaponToInteract;

    private void Start()
    {
        InputManager.instance.pickUp_drop.started += PickUpAndDrop;
        shootScript = GetComponent<Shoot>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag("Weapon"))
            return;
        
        weaponToInteract = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Weapon"))
            return;
        
        weaponToInteract = null;
    }

    public void PickUpAndDrop(InputAction.CallbackContext context)
    {
        if (weaponToInteract == null)
            return;

        if (!shootScript.isAWeaponEquipped)
        {
            weaponToInteract.transform.SetParent(weaponSlot);
            weaponToInteract.transform.localPosition = Vector3.zero;
            weaponToInteract.transform.localRotation = Quaternion.Euler(-90,0,0);
            
            shootScript.isAWeaponEquipped = true;
        }
        else
        {
            weaponToInteract.transform.SetParent(null);
            weaponToInteract.transform.position = transform.position;
            weaponToInteract.transform.localRotation = Quaternion.Euler(0,0,0);
            weaponToInteract = null;
            
            shootScript.isAWeaponEquipped = false;
        }
        
        
        
    }
    
}
