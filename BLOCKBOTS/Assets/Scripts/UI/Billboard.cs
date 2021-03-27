using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform tra;
    private void Start()
    {
        tra = CameraManager.instance.Cam.transform;
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position+ tra.forward);
    }
}
