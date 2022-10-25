using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotationLock : MonoBehaviour
{


    // Start is called before the first frame update
    public void HealthBarOrient(float rotationAngle)
    {
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -1 * rotationAngle));
        transform.localPosition = new Vector3(0, -6, -6);
    }
}
