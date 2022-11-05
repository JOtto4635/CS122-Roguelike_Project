using UnityEngine;

public class powerup : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            GameObject player = coll.gameObject;
            TestBullets_2 playerScript = player.GetComponent<TestBullets_2>();

            playerScript.minDamage = 100f;
            playerScript.maxDamage = 100f;
            Destroy(this.gameObject);
           
        }
    }
}
