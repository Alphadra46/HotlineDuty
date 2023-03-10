using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using Random = UnityEngine.Random;

public class Enemy_AI : MonoBehaviour
{
    public float AttackDamage;

    public float AttackStart = 0f;

    public float AttackCooldown = 1.25f;
    
    public PlayerStats playerStats;

    
    void Start()
    {
        var Player = GameObject.FindWithTag("Player");
        var SelfAi = gameObject.GetComponentInParent<AIDestinationSetter>();
        SelfAi.target = Player.transform;
        
    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player is in range");
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player is out of range");
            if (Time.time >= AttackStart + AttackCooldown)
            {
                AttackStart = Time.time;
                Attack();
                
            }
        }
    }
    
    
    private void Attack()
    {
        playerStats.life -= AttackDamage;
    }


}
