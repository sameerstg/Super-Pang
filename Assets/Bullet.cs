using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float force= 2;
   void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * force;    
    }

   
}
