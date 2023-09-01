using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : Enemy {

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Vector2 targetPosition;
    private Animator anim;
    public float stopDistance;
    public float attackSpeed;
    private float attackTime;
    public float timeBetweenSummons;
    private float summonTime;
    public Enemy enemytoSummon;
    public float MeleeAttackSpeed;

    public override void Start()
    {
        base.Start();
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        targetPosition = new Vector2(randomX, randomY);
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        if(player != null) {
            if ((Vector2)transform.position != targetPosition)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                anim.SetBool("isRunning", true);
            }
            else{
                anim.SetBool("isRunning", false);
                if(Time.time >= summonTime)
                {
                    summonTime = Time.time + timeBetweenSummons;
                    anim.SetTrigger("Summon");
                }
            }
        if (Vector2.Distance(transform.position, player.position) < stopDistance)
        {
            if (Time.time >= attackTime)
            {
                attackTime = Time.time + timeBetweenAttacks;
                StartCoroutine(Attack());
            }        
        }
    }

    void Summon()
    {
        if (player != null)
        {
            Instantiate(enemytoSummon, transform.position, transform.rotation);
        }
    }

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

}}