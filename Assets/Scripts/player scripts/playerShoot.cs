using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
    public Transform bulletOrigin;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            soundManager.PlaySound("player_shoot");
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletOrigin.position, bulletOrigin.rotation);
        
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bulletOrigin.up * bulletSpeed, ForceMode2D.Impulse);
    }
}