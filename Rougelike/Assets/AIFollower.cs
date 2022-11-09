using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollower : MonoBehaviour
{

    public GameObject player;
    public float MoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        transform.position += (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized * MoveSpeed * Time.deltaTime;
        //transform.rotation.z = (Camera.main.ScreenToWorldPoint(Input.mousePosition));

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));

        transform.rotation =  Quaternion.Euler(new Vector3(0f , 0f, (angle + 90)));

     }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
