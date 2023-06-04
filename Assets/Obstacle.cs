using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    public float force;
    public Vector2 direction;
    void Start()
    {
        if (force == 0)
        {
            force = 5;
        }
        GetComponent<Rigidbody2D>().AddForce(direction*force,ForceMode2D.Impulse);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Bullet") )
        {
            if (transform.localScale.x != .5f)
            {
                gameObject.transform.localScale /= 2;
                Instantiate(gameObject, transform.position, Quaternion.identity).GetComponent<Obstacle>().direction = Vector2.right;
                Instantiate(gameObject, transform.position, Quaternion.identity).GetComponent<Obstacle>().direction = Vector2.left;
            }
            
            Destroy(gameObject);
            Destroy(collision.gameObject);

        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


}
