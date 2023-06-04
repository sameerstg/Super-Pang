using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public GameObject bullet;
    public Rigidbody2D rb;
    public Vector2 direction;
    public SpriteRenderer spriteRenderer;
    bool isFiring;
    private void Awake()
    {
        rb  = GetComponent<Rigidbody2D>();
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }
    
    

    public void Fire()
    {
        

        Destroy(Instantiate(bullet, (direction * 2) + new Vector2(transform.position.x, transform.position.y), Quaternion.identity), 5);
    }

   

    public void Move(Vector2 dir)
    {
        if (dir == Vector2.right)
        {
            spriteRenderer.flipX = false;
        }
           else if (dir == Vector2.left)
        {
            
        }
        {
            spriteRenderer.flipX = true;

        }
        rb.velocity = dir * moveSpeed;
        if (dir != Vector2.zero)
        {
            direction = dir;
        }
    }
}
