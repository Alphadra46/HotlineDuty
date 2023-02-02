using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject ammoBox;
    [SerializeField] private PlayerStats playerStats;

    private void Start()
    {
        playerStats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Weapon") && !collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Furniture"))
        {
            Destroy(gameObject);
        }
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyDrop();
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Weapon") && !other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Furniture"))
        {
            Destroy(gameObject);
        }
      
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyDrop();
            Destroy(other.gameObject);
            
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Weapon") && !collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Furniture"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyDrop();
            Destroy(collision.gameObject);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Weapon") && !other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Furniture"))
        {
            Destroy(gameObject);
        }
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyDrop();
            Destroy(other.gameObject);
            
        }
    }

    private void EnemyDrop()
    {
        var luck = Random.Range(0, 100);
        if (luck <= 15)
        {
            Instantiate(ammoBox, transform.position, Quaternion.identity);
            playerStats.score += 100;
            
            Destroy(gameObject);
            
        }
        else
        {
            playerStats.score += 100;
            Destroy(gameObject);
            
        }
    }
    
}
