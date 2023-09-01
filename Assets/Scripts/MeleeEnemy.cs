using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public float stopDistance; // The distance at which the enemy stops moving towards the player.
    
    private float attackTime; // The time when the enemy can perform the next attack.
    
    public float attackSpeed; // The speed at which the enemy performs the attack.

    private void Update()
    {
        // Check if the player is not null (still exists in the game).
        if (player != null)
        {
            // If the distance is greater than the stopDistance, move towards the player.
            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else
            {
                // If it's time to attack, initiate the attack coroutine.
                if (Time.time >= attackTime)
                {
                    attackTime = Time.time + timeBetweenAttacks;
                    StartCoroutine(Attack());
                }
            }
        }
    }

    // Coroutine for handling the enemy's attack.
    IEnumerator Attack()
    {
        // Inflict damage to the player.
        player.GetComponent<Player>().TakeDamage(damage);

        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = player.position;

        float percent = 0f;
        while (percent <= 1)
        {
            // Calculate interpolation for smooth attack motion.
            percent += Time.deltaTime * attackSpeed;
            float interpolation = (-Mathf.Pow(percent, 2) + percent) * 4;

            // Move the enemy smoothly between original and target positions.
            transform.position = Vector2.Lerp(originalPosition, targetPosition, interpolation);
            yield return null;
        }
    }
}
