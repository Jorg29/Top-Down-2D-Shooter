using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;             // The movement speed of the player.
    private Rigidbody2D rb;         // Reference to the player's Rigidbody2D component.
    private Animator anim;          // Reference to the player's Animator component.
    private Vector2 moveAmount;     // The calculated movement amount based on input.
    public float health;            // The player's health.

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   // Get the Rigidbody2D component.
        anim = GetComponent<Animator>();    // Get the Animator component.
    }

    // Update is called once per frame
    void Update()
    {
        // Get player input for movement.
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Calculate the movement amount and normalize it.
        moveAmount = moveInput.normalized * speed;

        // Set the "isRunning" parameter in the Animator based on movement input.
        if (moveInput != Vector2.zero)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    private void FixedUpdate()
    {
        // Move the player's Rigidbody2D position based on the calculated movement amount.
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }

    // Method to handle when the player takes damage.
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        // Check if the player's health is zero or below.
        if (health <= 0)
        {
            // Destroy the player GameObject.
            Destroy(gameObject);
        }
    }
}
