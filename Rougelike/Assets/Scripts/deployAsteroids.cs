using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployAsteroids : MonoBehaviour
{
    HealthBar asteroidHealthBar = new HealthBar();
    public GameObject asteroidPrefab;
    public float respawnTime = 1.0f;
    public float size = 1.0f;
    public float maxSize = 1.5f;
    public float rotationAngle;
    private Vector2 screenBounds;



    RotationLock Orientation = new RotationLock();

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWave());
    }

    void spawnEnemy()
    {
        
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        rotationAngle = Random.value * 360f;
        a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * -2);
        a.transform.eulerAngles = new Vector3(0.0f, 0.0f, rotationAngle);
    }

    IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}
