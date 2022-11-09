using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Player : MonoBehaviour
{


    public float maxHealth = 200;
    public float maxShield = 100;
    public float maxShieldDelay = 5;
    public float currentHealth;
    public float currentShield;
    public float shieldDelay = 0;

    public HealthBar playerhealthbar;
    public HealthBar playershieldbar;

    public GameObject defaultBullet;
    public GameObject bullet2Prefab;
    public GameObject bullet3Prefab;
    public GameObject bullet4Prefab;
    public GameObject explosionPrefab;

    private float powerUpTime = 0;

    public SpriteRenderer spriteRenderer;
    public Sprite defaultShipSprite;
    public Sprite shipPowerUp1;
    public Sprite shipPowerUp2;
    public Sprite shipPowerUp3;

    public Animator animator;
    public RuntimeAnimatorController defaultShipController;
    public RuntimeAnimatorController powerUpController1;
    public RuntimeAnimatorController powerUpController2;
    public RuntimeAnimatorController powerUpController3;

    



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentShield = maxShield;
        playerhealthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {                                                               // Shield generation
        if(currentShield < maxShield)                               // Check shield status
        {
            if (shieldDelay > 0)                                    // Check shield delay
            {
                shieldDelay -= 1 * Time.deltaTime;                  // Decrease delay by 1 second
            }
            else
            {
                currentShield += (2 * Time.deltaTime);              // Add 2 shield to bar
                if (currentShield > maxShield)
                {
                    currentShield = maxShield;                      // If overshield occurs, set shield to max instead
                    playershieldbar.SetHealth(currentShield);       // Send max value to UI bar
                }
                else
                {
                    playershieldbar.SetHealth(currentShield);       // Send current value to UI bar
                }
            }
        }

        if (powerUpTime > 0)
        {
            powerUpTime -= Time.deltaTime;
        }
        if (powerUpTime <= 0)
        {
            setBulletPowerUp(defaultBullet);
            setShipPowerUp(defaultShipSprite, defaultShipController, 1, 5);
        }
    }

    void TakeDamage(float damage)
    {
        
        if(currentShield >= 0)                              // Check shield bar
        {
            currentShield -= damage;
            if(currentShield <= 0)                          // If shield falls below zero, take remaining damage to health
            {
                currentHealth += currentShield;
                playerhealthbar.SetHealth(currentHealth);
                currentShield = 0;
                playershieldbar.SetHealth(currentShield);   // Set shield bar to zero
                shieldDelay = maxShieldDelay;
            }
            else                                            // Set shield bar to remaining shield
            {
                playershieldbar.SetHealth(currentShield);
                shieldDelay = maxShieldDelay;               // Set shield regeneration delay
            }
        }

        else                                                // If no shield, take full damage to health.
        {
            currentHealth -= damage;
            playerhealthbar.SetHealth(currentHealth);
            shieldDelay = maxShieldDelay;                   // Set shield regeneration delay
        }

        CheckHealth(currentHealth);
    }

    private void setBulletPowerUp(GameObject prefab)
    {
        GameObject player = this.gameObject;
        TestBullets_2 playerScript = player.GetComponent<TestBullets_2>();
        playerScript.projectile = prefab;

    }

    private void setShipPowerUp(Sprite newSprite, RuntimeAnimatorController newController, float newFireRate, float newMaxLife)
    {
        GameObject player = this.gameObject;
        TestBullets_2 playerScript = player.GetComponent<TestBullets_2>();

        animator.runtimeAnimatorController = newController;
        spriteRenderer.sprite = newSprite;

        playerScript.fireRate = newFireRate;
        playerScript.maxLifetime = newMaxLife;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.name == "asteroid(Clone)")
        {
            Destroy(coll.gameObject);
            TakeDamage(50);
        }

        if (coll.gameObject.name == "bulletPower1(Clone)")
        {
            powerUpTime = 10f;
            setBulletPowerUp(bullet2Prefab);
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.name == "bulletPower2(Clone)")
        {
            powerUpTime = 10f;
            setBulletPowerUp(bullet3Prefab);
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.name == "bulletPower3(Clone)")
        {
            powerUpTime = 10f;
            setBulletPowerUp(bullet4Prefab);
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.name == "shipPower1(Clone)")
        {
            powerUpTime = 10f;
            setShipPowerUp(shipPowerUp1, powerUpController1, 3, 5);
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.name == "shipPower2(Clone)")
        {
            powerUpTime = 10f;
            setShipPowerUp(shipPowerUp2, powerUpController2, 6, 3);
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.name == "shipPower3(Clone)")
        {
            powerUpTime = 10f;
            setShipPowerUp(shipPowerUp3, powerUpController3, 10, 2);
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.name == "Bullet 2(Clone)")
        {
            Destroy(coll.gameObject);
            TakeDamage(20);
        }

    }

    void CheckHealth(float currentHealth)
    {
        if(currentHealth <= 0)
        {

            Vector3 deathPosition = this.gameObject.transform.position;
            GameObject explosion = Instantiate(explosionPrefab) as GameObject;
            explosion.transform.position = deathPosition;

          //  explosion.transform.SetParent(GameObject.FindGameObjectWithTag("ui").transform, true);

            Destroy(this.gameObject);
        }
    }
}
