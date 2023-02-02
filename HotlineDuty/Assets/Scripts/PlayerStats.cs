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
    public int score;
    public float AttackDamage;

    public float AttackStart = 0f;

    public float AttackCooldown = 1.25f;

    public bool isDead;
    
    

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

        if (GetComponent<PickUpScript>().weaponToInteract != null)
        {
            actualWeapon = GetComponent<PickUpScript>().weaponToInteract.GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            actualWeapon = null;
        }
        
        if (life <= 0)
        {
            isDead = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            if (Time.time >= AttackStart + AttackCooldown)
            {
                AttackStart = Time.time;
                life--;

            }
        }
    }
}
