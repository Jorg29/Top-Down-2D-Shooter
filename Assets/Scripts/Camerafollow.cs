using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public Transform playerTransform; // The target the camera will follow.
    public float speed;               // The speed at which the camera follows the target.
    public float minx;                // The minimum x-coordinate the camera can reach.
    public float maxx;                // The maximum x-coordinate the camera can reach.
    public float miny;                // The minimum y-coordinate the camera can reach.
    public float maxy;                // The maximum y-coordinate the camera can reach.

    // Start is called before the first frame update
    void Start()
    {
        // Set the initial camera position to match the player's position.
        transform.position = playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the playerTransform is not null (player still exists).
        if (playerTransform != null)
        {
            // Calculate clamped positions within the defined boundaries.
            float clampedx = Mathf.Clamp(playerTransform.position.x, minx, maxx);
            float clampedy = Mathf.Clamp(playerTransform.position.y, miny, maxy);
            
            // Smoothly move the camera towards the clamped position.
            transform.position = Vector2.Lerp(transform.position, new Vector2(clampedx, clampedy), speed);
        }
    }
}
