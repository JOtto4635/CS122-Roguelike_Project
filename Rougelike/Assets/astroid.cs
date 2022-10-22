using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class astroid : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    public float asteroidHealth = 50.0f;
    public HealthBar asteroidHealthBar;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < screenBounds.y * 10)
        {
            Destroy(this.gameObject);
        }
        
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Bullet 4")
        {
            TakeDamage(10);
        }
    }

    void TakeDamage(float damage)
    {
        asteroidHealth = asteroidHealth - damage;
        if(asteroidHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
