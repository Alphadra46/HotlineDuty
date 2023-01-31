using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float life = 4f;
    public float maxLife = 4f;
    public Sprite actualWeapon;
    public Sprite playerSpriteWithGun;
    public Sprite playerSpriteWithoutGun;
    
    

    private void Update()
    {
        if (GetComponent<Shoot>().isAWeaponEquipped)
        {
            GetComponent<SpriteRenderer>().sprite = playerSpriteWithGun;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = playerSpriteWithoutGun;
        }
        
        actualWeapon = GetComponent<PickUpScript>().weaponToInteract.GetComponent<SpriteRenderer>().sprite;
        
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
