using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Player playerScript;
    private Vector2 targetPosition;
    public float speed;
    public int damage;
    public float lifeTime;
    public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        targetPosition = playerScript.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector2)transform.position == targetPosition)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        } 
        else {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerScript.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
