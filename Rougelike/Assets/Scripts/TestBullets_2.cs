using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBullets_2 : MonoBehaviour
{
    public GameObject projectile;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;
    public float maxLifetime;
    public float fireRate = 1.0f;   // Default firerate 1 shot per second
    private float shotCheck = 1;

    private Vector2 direction;

    void Update()
    {
        if (shotCheck > 0)
        {
            shotCheck -= Time.deltaTime * fireRate * 3;
        }
        
        if (Input.GetMouseButton(0)) // 0 for left click 1 for right click
        {
            
            if(shotCheck <= 0)
            {
                GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
                Vector2 direction = Vector2.up;
                bullet.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
                shotCheck = 1;
                Destroy(bullet, maxLifetime);  // Destroy the bullets after a certain time on screen
            }                                                         
        }
    }
}
