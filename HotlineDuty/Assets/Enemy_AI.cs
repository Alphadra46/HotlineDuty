using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class Enemy_AI : MonoBehaviour
{
    public float AttackDamage;

    public float AttackStart = 0f;

    public float AttackCooldown = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        var Player = GameObject.Find("Player");
        var SelfAi = gameObject.GetComponentInParent<AIDestinationSetter>();
        SelfAi.target = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Player is in range");
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
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
        
    }
}
