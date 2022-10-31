using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class astroid : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    public float asteroidHealth = 50;
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

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.name == "Bullet 4(Clone)")
        {
            Destroy(coll.gameObject);
            TakeDamage(10);
        }
    }

    void TakeDamage(float damage)
    {
        asteroidHealth = asteroidHealth - damage;
        asteroidHealthBar.SetHealth(asteroidHealth);
        if (asteroidHealth <= 0)
        {
            var exp = GetComponent<Explosion>();
            exp.Play();
            Destroy(this.gameObject);

        }
    }
}
