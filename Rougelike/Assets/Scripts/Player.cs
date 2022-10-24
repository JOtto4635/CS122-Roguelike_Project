using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Player : MonoBehaviour
{
    private GameObject player1 = default;

    public int maxHealth = 200;
    public int currentHealth;

    public HealthBar playerhealthbar;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        playerhealthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        playerhealthbar.SetHealth(currentHealth);
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

    void CheckHealth(int currentHealth)
    {
        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
