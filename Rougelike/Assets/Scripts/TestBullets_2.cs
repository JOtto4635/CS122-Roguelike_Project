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

    private Vector2 direction;



    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 for left click 1 for right click
        {
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 direction = Vector2.up;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            Destroy(bullet, maxLifetime);
        }
    }
}
