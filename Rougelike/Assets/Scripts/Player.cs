using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Player : MonoBehaviour
{
    private GameObject player1 = default;

    public float maxHealth = 200;
    public float maxShield = 100;
    public float maxShieldDelay = 5;
    public float currentHealth;
    public float currentShield;
    public float shieldDelay = 0;

    public HealthBar playerhealthbar;
    public HealthBar playershieldbar;



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
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.name == "asteroid(Clone)")
        {
            Destroy(coll.gameObject);
            TakeDamage(50);
            CheckHealth(currentHealth);
        }
    }

    void CheckHealth(float currentHealth)
    {
        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
