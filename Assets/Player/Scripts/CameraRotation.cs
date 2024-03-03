using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform CameraAxisTransform;
    public float RotationSpeed = 1.0f; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + RotationSpeed * Input.GetAxis("Mouse X") * Time.deltaTime, 0);

        CameraAxisTransform.localEulerAngles = new Vector3(CameraAxisTransform.localEulerAngles.x + RotationSpeed/2 * Input.GetAxis("Mouse Y") * Time.deltaTime, 0, 0);
    }
}
