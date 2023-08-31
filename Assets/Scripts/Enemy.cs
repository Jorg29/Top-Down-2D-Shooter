using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Public variables that can be adjusted in the Unity Inspector
    public int health;
    [HideInInspector] public Transform player;
    public float speed;
    public float timeBetweenAttacks;
    public int damage;

    // Start method is called when the enemy object is instantiated
    public virtual void Start()
    {
        // Find the player object using the "Player" tag and store its transform
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Method for dealing damage to the enemy
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        // Check if the enemy's health has dropped to or below zero
        if (health <= 0)
        {
            // Destroy the enemy GameObject if its health is zero or negative
            Destroy(gameObject);
        }
    }
}
