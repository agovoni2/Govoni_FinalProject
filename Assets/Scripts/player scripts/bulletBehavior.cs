using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
    public float bulletSpeed = 30f;
    public Rigidbody2D rb;

    public float despawn = 5f;

    void Start()
    {
        // Despawns the projectile after a certain amount of time
        Destroy(gameObject, despawn);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, despawn);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "border")
        {
            Destroy(gameObject, despawn);
        }

        Destroy(gameObject);
    }
}