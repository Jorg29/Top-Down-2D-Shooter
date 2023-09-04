using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;          // The speed of the projectile
    public float lifeTime;       // The lifespan of the projectile
    public GameObject explosion; // The explosion prefab
    public int damage;           // The damage the projectile deals
    public GameObject soundOdject;

    private void Start()
    {
        // Invoke the DestroyProjectile method after the specified lifetime
        Invoke("DestroyProjectile", lifeTime);
        Instantiate(soundOdject, transform.position, transform.rotation);
    }

    private void Update()
    {
        // Move the projectile forward based on its speed
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        // Destroy the projectile GameObject
        Destroy(gameObject);

        // Instantiate an explosion at the projectile's position
        Instantiate(explosion, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the projectile collides with an object with the "Enemy" tag
        if (collision.tag == "Enemy")
        {
            // Get the "Enemy" component from the collided object and apply damage
            collision.GetComponent<Enemy>().TakeDamage(damage);

            // Destroy the projectile
            DestroyProjectile();
        }
        if (collision.tag == "Boss")
        {
            // Get the "Enemy" component from the collided object and apply damage
            collision.GetComponent<Boss>().TakeDamage(damage);

            // Destroy the projectile
            DestroyProjectile();
        }
    }
}
