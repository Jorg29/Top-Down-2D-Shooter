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
        }
    }
}