using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity
{
    //private float speed = 3.5f;
    private Vector3 dir;
    private SpriteRenderer sprite;
    private Animator anim;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject==Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
            lives--;

        }
        if (lives < 1)
            Die();
    }

        
    private void Start()
    {
        lives = 3;
        //dir = transform.right;
    }
    private void Update()
    {
        //Move();
    }

    //private void Move()
    //{
    //    Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.1f + transform.right * dir.x * 0.7f, 0.1f);

    //    if (colliders.Length > 0) dir *= -0f;
    //    transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, Time.deltaTime);
    //    sprite.flipX = dir.x < 0.0f;
    //}
    
}
