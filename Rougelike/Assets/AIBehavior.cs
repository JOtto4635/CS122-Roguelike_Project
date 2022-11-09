using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehavior : MonoBehaviour
{
    public float shotCheck = 8;
    public float enemyHealth = 100;
    public float projectileForce = 800;
    public float maxLifetime;
    public float fireRate = 1.0f;
    public HealthBar enemyHealthBar;

    public GameObject projectile;
    public GameObject explosionPrefab;
    public Transform GunBarrel;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (shotCheck > 0)
        {
            shotCheck -= Time.deltaTime * fireRate * 2;
        }

        if (shotCheck <= 0)
        {
            GameObject bullet = Instantiate(projectile, GunBarrel.position, GunBarrel.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = transform.up * projectileForce;
            shotCheck = Random.Range(2,10);
            Destroy(bullet, maxLifetime);  // Destroy the bullets after a certain time on screen
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Bullet 1(Clone)")
        {
            Destroy(coll.gameObject);
            TakeDamage(10);
        }

        if (coll.gameObject.name == "Bullet 2(Clone)")
        {
            Destroy(coll.gameObject);
            TakeDamage(20);
        }

        if (coll.gameObject.name == "Bullet 3(Clone)")
        {
            Destroy(coll.gameObject);
            TakeDamage(30);
        }

        if (coll.gameObject.name == "Bullet 4(Clone)")
        {
            Destroy(coll.gameObject);
            TakeDamage(40);
        }

        if (coll.gameObject.name == "asteroid(Clone)")
        {
            Destroy(coll.gameObject);
            TakeDamage(20);
        }
    }
   

    void TakeDamage(float damage)
    {
        enemyHealth = enemyHealth - damage;
        enemyHealthBar.SetHealth(enemyHealth);
        if (enemyHealth <= 0)
        {
            Vector3 deathPosition = this.gameObject.transform.position;
            GameObject explosion = Instantiate(explosionPrefab) as GameObject;
            explosion.transform.position = deathPosition;
            //  CheckItemDrops(deathPosition);

            Destroy(this.gameObject);

        }
    }
}
