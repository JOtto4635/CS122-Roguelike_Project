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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
            //CheckHealth(currentHealth);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        playerhealthbar.SetHealth(currentHealth);
    }

 
/*
    void CheckHealth(int currentHealth)
    {
        if(currentHealth <= 0)
        {
            Destroy(this.GameObject);
        }
    }
*/

}
