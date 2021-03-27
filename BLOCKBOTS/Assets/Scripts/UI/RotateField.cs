using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateField : MonoBehaviour
{
    public FixedTouchField TouchField;
    protected float CameraAngle;
    protected float CameraAngleSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - Camera.main.transform.position, Vector3.up);
    }
}
