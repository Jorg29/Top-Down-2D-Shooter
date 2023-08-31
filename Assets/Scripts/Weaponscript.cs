using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponscript : MonoBehaviour
{
    public GameObject projectile;       // The projectile prefab to be shot
    public Transform shotPoint;         // The point from which projectiles will be shot
    public float timeBetweenShots;      // The delay between shots
    private float shotTime;             // The time when the next shot can occur

    private void Update()
    {
        // Calculate the direction from the weapon to the mouse cursor
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        
        // Calculate the angle based on the direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        // Create a rotation based on the calculated angle
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        
        // Apply the calculated rotation to the weapon
        transform.rotation = rotation;

        // Check if the left mouse button is pressed
        if (Input.GetMouseButton(0))
        {
            // Check if enough time has passed since the last shot
            if (Time.time >= shotTime)
            {
                // Create a projectile at the shot point with the calculated rotation
                Instantiate(projectile, shotPoint.position, transform.rotation);

                // Set the time when the next shot can occur
                shotTime = Time.time + timeBetweenShots;
            }
        }
    }
}
