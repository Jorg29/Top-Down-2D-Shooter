using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public Weapon weaponToEquip;
    public GameObject effect;
    public float destroyDelay = 15.0f; // The time in seconds before destroying the pickup.

    private IEnumerator Start()
    {
        // Wait for 'destroyDelay' seconds before destroying the pickup.
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            collision.GetComponent<Player>().ChangeWeapon(weaponToEquip);
            Destroy(gameObject);
        }
    }


}