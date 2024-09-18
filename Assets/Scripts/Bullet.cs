using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject bullet;
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletDamping;
    Rigidbody2D rb;
    public bool isFacingRight = true;

    Vector2 dirextion;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dirextion = Vector2.right;
    }

    private void FixedUpdate()
    {
        Fire();
    }

    public void Fire()
    {
         
           dirextion =(isFacingRight) ? Vector2.right : Vector2.left;
        rb.velocity = dirextion * bulletSpeed; 
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enermy"))
        {
            Destroy(gameObject);
        }
    }
}
